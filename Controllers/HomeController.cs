using EstateWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EstateWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEstateRepo _estateRepo;
        public HomeController(ILogger<HomeController> logger, IEstateRepo estateRepo)
        {
            _logger = logger;
            _estateRepo = estateRepo;
        }
        public static List<SelectListItem> GetEnumSelectList<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            var selectList = enumValues.Select((e, i) => new SelectListItem
            {
                Value = i.ToString(),
                Text = e.ToString()
            }).ToList();

            return selectList;
        }
        public IActionResult Index(string? seachName,[FromQuery] Category? categoryName)
        {
            var estates = _estateRepo.GetEstates();
            if (!string.IsNullOrEmpty(seachName))
            {
                estates = _estateRepo.SearchByName(seachName);
            }
            else if (categoryName.HasValue)
            {
                estates = estates.Where(p => p.Category == categoryName.Value).ToList();
            }
            ViewBag.selectCategories = GetEnumSelectList<Category>();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
