
using EstateWebsite.Models;

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

        public byte[] SaveImageInDatabase(IFormFile file)
        {
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        public string SaveImgInServer(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            var path = Path.Combine($"{_webHostEnvironment.WebRootPath}{Settings.imagesPath}", fileName);
            using var stream = File.Create(path);
            file.CopyTo(stream);
            return fileName;
        }
    }
}
