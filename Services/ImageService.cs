
namespace EstateWebsite.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetImagePath(string image)
        {
            return Path.Combine($"{_webHostEnvironment.WebRootPath}{Settings.imagesPath}", image);
        }

        public string SaveImgInServer(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}{Settings.imagesPath}", fileName);
            using var stream = File.Create(path);
            file.CopyToAsync(stream);
            return fileName;
        }
    }
}
