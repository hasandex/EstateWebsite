namespace EstateWebsite.ViewModel
{
    public class UpdateEstateImagesVM
    {
        public int Id { get; set; }
        [AllowedExtension(Settings.allowedExtensions)]
        [MaxFileSize(Settings.maxFileSizeImg)]
        public List<IFormFile>? FormFiles { get; set; }
        public IEnumerable<string>? Images { get; set; } = Enumerable.Empty<string>();
    }
}
