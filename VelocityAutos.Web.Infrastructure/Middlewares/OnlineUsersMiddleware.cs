using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.GeneralApplicationConstants;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace VelocityAutos.Web.Infrastructure.Middlewares
{
    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityThresholdInMinutes;

        private static readonly ConcurrentDictionary<string, bool> AllKeys = 
            new ConcurrentDictionary<string, bool>();

        public OnlineUsersMiddleware(RequestDelegate next,
            string cookieName = OnlineUsersCookieName,
            int lastActivityThresholdInMinutes = LastActivityThresholdInMinutes)
        {
            this.next = next;
            this.cookieName = cookieName;
            this.lastActivityThresholdInMinutes = lastActivityThresholdInMinutes;

        }

        public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    userId = context.User.GetId()!;
                    context.Response.Cookies.Append(this.cookieName, userId, new CookieOptions
                    {
                        HttpOnly = true,
                        MaxAge = TimeSpan.FromDays(30)
                    });
                }

                memoryCache.GetOrCreate(userId, entry =>
                {
                    if (AllKeys.TryAdd(userId, true))
                    {
                        entry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        entry.SlidingExpiration = TimeSpan.FromMinutes(this.lastActivityThresholdInMinutes);
                        entry.RegisterPostEvictionCallback(this.RemoveKeyWhenExpired);
                    }

                    return string.Empty;
                });
            }
            else
            {
                if (context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }
                    
                    context.Response.Cookies.Delete(this.cookieName);
                }
            }

            return this.next(context);
        }

        public static bool CheckIfUserIsOnline(string userId)
        {
            bool takenValue = AllKeys.TryGetValue(userId.ToLower(), out bool isSuccessful);

            return isSuccessful && takenValue;
        }

        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyString = (string)key;

            if (!AllKeys.TryRemove(keyString, out _))
            {
                AllKeys.TryUpdate(keyString, false, true);
            }
        }
    }
}
