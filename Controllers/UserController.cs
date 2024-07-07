using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebsite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ICommentRepo commentRepo)
        {

            _userService = userService;
            _commentRepo = commentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment([Bind("Id,Content,UserId,EstateId")] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            _commentRepo.Add(comment);
            return RedirectToAction("Detail", "Estate", new { estateId = comment.EstateId });
        }
        //public IActionResult RemoveComment(int commentId)
        //{
        //    _commentRepo.RemoveComment(commentId);
        //    return RedirectToAction("Detail", "Estate", new { estateId = commentId });
        //}
    }
}
