
namespace EstateWebsite.ViewModel
{
    public class UpdateEstateVM : BaseEstateVM
    {
        public int Id {  get; set; }
        [AllowedExtension(Settings.allowedExtensions)]
        [MaxFileSize(Settings.maxFileSizeImg)]
        public IFormFile? FormCover { get; set; } // for upload
        [AllowedExtension(Settings.allowedExtensions)]
        [MaxFileSize(Settings.maxFileSizeImg)]
        public byte[]? Cover { get; set; } // for display
    }
}
