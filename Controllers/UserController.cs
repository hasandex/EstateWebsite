using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddComment([Bind("Id,Content,UserId,EstateId")] Comment comment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ModelState);
        //    }
        //    _commentRepo.Add(comment);
        //    return RedirectToAction("Detail", "Estate", new { estateId = comment.EstateId });
        //}

        public IActionResult AddComment(string content, string userId, int estateId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var comment = new Comment
            {
                Content = content,
                UserId = userId,
                EstateId = estateId,
                CreatedDate = DateTime.Now,
            };
            var isAdded = _commentRepo.Add(comment);
            if (isAdded > 0)
            {
                return Ok(new { success = true, commentId = comment.Id });
            }
            return BadRequest(new { success = false, errors = new[] { "Failed to add the comment." } });
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
            return View(savedEstates);
        }
    }
}
