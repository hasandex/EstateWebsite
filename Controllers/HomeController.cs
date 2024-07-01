using EstateWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstateWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepo _homeRepo;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IHomeRepo homeRepo, IMapper mapper)
        {
            _logger = logger;
            _homeRepo = homeRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_homeRepo.GetHomes());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateHomeVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isAdded = _homeRepo.Create(viewModel);
            if (isAdded > 0)
                return RedirectToAction("Index");
            return BadRequest();
        }
        public IActionResult Update(int homeId)
        {
            var home = _homeRepo.GetById(homeId);
            if (home == null)
            {
                return BadRequest();
            }
            var viewModel = _mapper.Map<UpdateHomeVM>(home);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(UpdateHomeVM viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _homeRepo.Update(viewModel);
            if(isUpdated > 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        public IActionResult UpdateHomeImages(int homeId)
        {
            var home = _homeRepo.GetById(homeId);
            if(home != null)
            {
                var viewModel = new UpdateHomeImagesVM()
                {
                    Id = home.Id,
                    Images = home.HomeImages?.Select(image => image.Path).ToList(),
                };
                return View(viewModel);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateHomeImages(UpdateHomeImagesVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _homeRepo.UpdateHomeImages(viewModel);
            if(isUpdated >= 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult DeleteHomeImage(int homeId, string image)
        {
            var isDeleted = _homeRepo.DeleteHomeImage(homeId, image);
            if (isDeleted > 0)
            {
                return RedirectToAction("UpdateHomeImages", "Home", new { homeId = homeId });
            }
            return BadRequest();
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
