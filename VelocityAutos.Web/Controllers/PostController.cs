using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Delete(string id)
        {
            var post = await this.postService.GetPostForDelete(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
            }

            string currUserId = this.User.GetId();

            if (post.SellerId != currUserId.ToUpper())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to remove it!";
            }

            return this.View(post);
        }

        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var post = await this.postService.GetPostForDelete(id);

            if (post == null)
            {
                TempData[ErrorMessage] = "Post does not exist or is no longer available!";
            }

            string currUserId = this.User.GetId();

            if (post.SellerId != currUserId.ToUpper())
            {
                TempData[ErrorMessage] = "You have to be this post's owner in order to remove it!";
                return this.RedirectToAction("Details", "Car", new { id });
            }

            await this.postService.DeleteAsync(id);

            TempData[SuccessMessage] = "The post was successfully removed!";

            return this.RedirectToAction("All", "Car");
        }
    }
}
