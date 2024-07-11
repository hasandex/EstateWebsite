using Azure;
using EstateWebsite.Models;
using Google.Apis.Bigquery.v2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EstateWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEstateRepo _estateRepo;
        private readonly IEmailSender _emailSender;
        public HomeController(ILogger<HomeController> logger, IEstateRepo estateRepo,
            IEmailSender emailSender)
        {
            _logger = logger;
            _estateRepo = estateRepo;
            _emailSender = emailSender;
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
        public IActionResult Index()
        {
            ViewBag.estates = _estateRepo.GetEstates();
            ViewBag.selectCategories = GetEnumSelectList<Category>();
            ViewBag.selectGovernorate = GetEnumSelectList<Governorate>();
            var estatesGrouped = _estateRepo.GroupByCategory();
            var categoriesVM = new List<CategoriesEstatesVM>();
            foreach (var item in estatesGrouped)
            {
                categoriesVM.Add(new CategoriesEstatesVM()
                {
                    Category = item.Key,
                    Count = item.Count()
                });
            }
            return View(categoriesVM);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            string body = $"Name: {viewModel.Name}\nEmail: {viewModel.Email}\nMessage: {viewModel.Message}";
            await _emailSender.SendEmailAsync("hasansuliman375@gmail.com",viewModel.Subject, body);
            return RedirectToAction("Index");
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
