using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateWebsite.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateRepo _estateRepo;
        private readonly IMapper _mapper;

        public EstateController( IEstateRepo estateRepo, IMapper mapper)
        {
            _estateRepo = estateRepo;
            _mapper = mapper;
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
           return View(_estateRepo.GetEstates());
        }
        public IActionResult Explore(string? forSale, string? forRent, string? searchName, [FromQuery] Category? categoryName,
            [FromQuery] Governorate? governorate , int? minPrice, int? maxPrice)
        {
            var estates = _estateRepo.GetEstates();
            if (!string.IsNullOrEmpty(searchName))
            {
                estates = _estateRepo.SearchByName(searchName);
            }
            if (categoryName.HasValue)
            {
                estates = estates.Where(p => p.Category == categoryName.Value).ToList();
            }
            if (governorate.HasValue)
            {
                estates = estates.Where(p => p.Governorate == governorate.Value).ToList();
            }
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                estates = estates.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            }
            if(forSale == "forSale")
            {
                estates = estates.Where(p => p.ForSale == true).ToList();
            }
            if(forRent == "forRent")
            {
                estates = estates.Where(p => p.ForRent == true).ToList();
            }
            ViewBag.selectCategories = GetEnumSelectList<Category>();
            ViewBag.selectGovernorate = GetEnumSelectList<Governorate>();
            //now we will get the user's inputs to display them in their boxes
            ViewBag.category = categoryName;
            ViewBag.governorate = governorate;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.searchName = searchName;
            ViewBag.forSale = forSale;
            ViewBag.forRent = forRent;
            return View(estates);
        }
        public IActionResult Create()
        {
            var viewModel = new CreateEstateVM()
            {
                SelectCategory = GetEnumSelectList<Category>(),
                SelectMethodPay = GetEnumSelectList<MethodPay>(),
                SelectLegalType = GetEnumSelectList<LegalType>(),
                SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>(),
                SelectGovernorate = GetEnumSelectList<Governorate>(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateEstateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectCategory = GetEnumSelectList<Category>();
                viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
                viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
                viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
                viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();
           
                return View(viewModel);
            }
            var isAdded = _estateRepo.Create(viewModel);
            if (isAdded > 0)
                return RedirectToAction("Index");
            return BadRequest();
        }
        public IActionResult Update(int estateId)
        {
            var estate = _estateRepo.GetById(estateId);
            if (estate == null)
            {
                return BadRequest();
            }
            var viewModel = _mapper.Map<UpdateEstateVM>(estate);
            viewModel.SelectCategory = GetEnumSelectList<Category>();
            viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
            viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
            viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
            viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateEstateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectCategory = GetEnumSelectList<Category>();
                viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
                viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
                viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
                viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();
                return View(viewModel);
            }
            var isUpdated = _estateRepo.Update(viewModel);
            if (isUpdated > 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public IActionResult UpdateEstateImages(int estateId)
        {
            var estate = _estateRepo.GetById(estateId);
            if (estate != null)
            {
                var viewModel = new UpdateEstateImagesVM()
                {
                    Id = estate.Id,
                    Images = estate.EstateImages?.Select(image => image.Path).ToList(),
                };
                return View(viewModel);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateEstateImages(UpdateEstateImagesVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _estateRepo.UpdateEstateImages(viewModel);
            if (isUpdated >= 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public IActionResult Detail(int estateId)
        {
            var estate = _estateRepo.GetById(estateId);
            return View(estate);
        }

        public IActionResult Delete(int id)
        {
            var isDeleted = _estateRepo.Delete(id);
            if (isDeleted == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEstateImage(int estateId, string image)
        {
            var isDeleted = _estateRepo.DeleteEstateImage(estateId, image);
            if (isDeleted > 0)
            {
                return RedirectToAction("UpdateEstateImages", "Estate", new { estateId = estateId });
            }
            return BadRequest();
        }
    }
}
