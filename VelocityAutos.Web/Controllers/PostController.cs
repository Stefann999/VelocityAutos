using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Delete(string id)
        {
            var post = await this.postService.GetPostForDeleteAsync(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
                return this.RedirectToAction("All", "Car");
            }

            string currUserId = this.User.GetId()!;

            bool isOwner = post.SellerId == currUserId;

            if (!isOwner && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to remove it!";
                return this.RedirectToAction("Details", "Car", new { id });
            }

            return this.View(post);
        }

        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var post = await this.postService.GetPostForDeleteAsync(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
                return this.RedirectToAction("All", "Car");
            }

            string currUserId = this.User.GetId()!;

            bool isAdmin = post.SellerId == currUserId;

            if (!isAdmin && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to remove it!";
                return this.RedirectToAction("All", "Car");
            }

            try
            {
                await this.postService.DeleteAsync(id);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to add new car! Please try again later or contact administrator!";
                return this.RedirectToAction("Details", "Car", new { id });
            }

            TempData[SuccessMessage] = "The post was successfully removed!";

            return this.RedirectToAction("All", "Car");
        }

        public async Task<IActionResult> Activate(string id)
        {
            var post = await this.postService.GetPostForDeleteAsync(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
                return this.RedirectToAction("All", "Car");
            }

            string currUserId = this.User.GetId()!;

            bool isAdmin = post.SellerId == currUserId;

            if (!isAdmin && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to activate it!";
                return this.RedirectToAction("Details", "Car", new { id });
            }

            return this.View(post);
        }

        public async Task<IActionResult> ConfirmActivate(string id)
        {
            var post = await this.postService.GetPostForDeleteAsync(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
                return this.RedirectToAction("All", "Car");
            }

            string currUserId = this.User.GetId()!;

            bool isAdmin = post.SellerId == currUserId;

            if (!isAdmin && !this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to activate it!";
                return this.RedirectToAction("Details", "Car", new { id });
            }

            try
            {
                await this.postService.ActivateAsync(id);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occured while trying to activate the post! Please try again later or contact administrator!";
                return this.RedirectToAction("All", "Car");
            }

            TempData[SuccessMessage] = "The post was successfully activated!";

            return this.RedirectToAction("Details", "Car", new { id });
        }
    }
}
