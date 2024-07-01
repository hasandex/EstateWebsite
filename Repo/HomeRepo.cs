
using EstateWebsite.ViewModel;
using Microsoft.AspNetCore.Hosting;

namespace EstateWebsite.Repo
{
    public class HomeRepo : IHomeRepo
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public HomeRepo(AppDbContext context, IUserService userService, IImageService imageService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _imageService = imageService;
            _mapper = mapper;
        }
        public IEnumerable<Home> GetHomes()
        {
            return _context.Homes.ToList();
        }
        public IEnumerable<HomeImages> GetAllImages(int homeId)
        {
            var home = GetById(homeId);
            if (home != null)
            {
                return home.HomeImages?.ToList();
            }
            return null;
        }
        public int Create(CreateHomeVM viewModel)
        {
            var home = _mapper.Map<Home>(viewModel);
            home.UserId = _userService.GetUserId();
            MemoryStream stream = new MemoryStream();
            viewModel.FormCover.CopyTo(stream);
            home.Cover = stream.ToArray();
            List<HomeImages> homeImages = new List<HomeImages>();
            foreach (var item in viewModel.FormFiles)
            {
                var image = new HomeImages { Path = _imageService.SaveImgInServer(item) };
                homeImages.Add(image);
            }
            home.HomeImages = homeImages;
            _context.Homes.Add(home);
            return _context.SaveChanges();
        }

        public Home GetById(int homeId)
        {
            var home = _context.Homes?.Include(h => h.HomeImages)
                .Where(h=>h.Id == homeId).AsNoTracking().SingleOrDefault();
            if (home == null)
            {
                return null;
            }
            return home;
        }

        public int Update(UpdateHomeVM viewModel)
        {
            
            var home = GetById(viewModel.Id);
            byte[] oldCover = home.Cover;
            if (home == null)
            {
                return 0;
            }
            home = _mapper.Map<Home>(viewModel);
            home.UserId = _userService.GetUserId();
            if (viewModel.FormCover != null)
            {
                MemoryStream stream = new MemoryStream();
                viewModel.FormCover.CopyTo(stream);
                home.Cover = stream.ToArray();
            }
            else
            {
                home.Cover = oldCover;
            }
            _context.Homes.Update(home);
            return _context.SaveChanges();
        }

        public int UpdateHomeImages(UpdateHomeImagesVM viewModel)
        {
            var existingHome = GetById(viewModel.Id);

            if (existingHome == null)
            {
                return -1;
            }

            if (viewModel.FormFiles != null)
            {
                List<HomeImages> homeImages = new List<HomeImages>();
                foreach (var item in viewModel.FormFiles)
                {
                    var image = new HomeImages { Path = _imageService.SaveImgInServer(item) };
                    homeImages.Add(image);
                }
                existingHome.HomeImages = homeImages;
                _context.Homes.Update(existingHome);
                return _context.SaveChanges();
            }
            return 0;
        }
        public int DeleteHomeImage(int homeId, string image)
        {
            var home = GetById(homeId);
            if (home != null)
            {
                var img = home.HomeImages?.Where(hi => hi.Path == image).SingleOrDefault();
                if (img == null)
                {
                    return -1;
                }
                var path = _imageService.GetImagePath(image);
                File.Delete(path);
                _context.HomeImages.Remove(img);
                return _context.SaveChanges();
            }
            else
                return -1;
        }
    }
}
