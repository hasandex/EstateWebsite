namespace EstateWebsite.Services.IServices
{
    public interface IImageService
    {
       string SaveImgInServer(IFormFile file);
       string GetImagePath(string image);
    }
}
