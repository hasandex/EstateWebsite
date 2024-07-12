using EstateWebsite.CustomDataAnnotation;
using System.Configuration;

namespace EstateWebsite.ViewModel
{
    public class CreateEstateVM : BaseEstateVM
    {
        [AllowedExtension(Settings.allowedExtensions)]
        [MaxFileSize(Settings.maxFileSizeImg)]
        public IFormFile FormCover { get; set; }
        [AllowedExtension(Settings.allowedExtensions)]
        [MaxFileSize(Settings.maxFileSizeImg)]
        public List<IFormFile> FormFiles { get; set; }
    }
}
