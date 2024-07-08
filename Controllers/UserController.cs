using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstateWebsite.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        private readonly ISaveProperty _saveProperty;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ICommentRepo commentRepo, ISaveProperty saveProperty)
        {

            _userService = userService;
            _commentRepo = commentRepo;
            _saveProperty = saveProperty;
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
        public IActionResult RemoveComment(int commentId)
        {
            var isDelete = _commentRepo.RemoveComment(commentId);
            if(isDelete > 0)
            {
                return Ok();
            }
            return BadRequest();
           // return RedirectToAction("Detail", "Estate", new { estateId = commentId });
        }
        public IActionResult SaveProperty(int estateId)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var saved = _saveProperty.Save(estateId);
            if(saved > 0)
            {
                return RedirectToAction("Detail", "Estate", new { estateId = estateId });
            }
            return BadRequest();
        }
        public IActionResult RemoveProperty(int estateId)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var saved = _saveProperty.Remove(estateId);
            if (saved > 0)
            {
                return RedirectToAction("Detail", "Estate", new { estateId = estateId });
            }
            return BadRequest();
        }

        public IActionResult DisplaySaveEstates()
        {
            var savedEstates = _saveProperty.GetAllSavedEstates(_userService.GetUserId());
            var x = 3;
            return View(savedEstates);
        }
    }
}
