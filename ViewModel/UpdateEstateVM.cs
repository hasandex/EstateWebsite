namespace EstateWebsite.ViewModel
{
    public class UpdateEstateVM : BaseEstateVM
    {
        public int Id {  get; set; }
        public IFormFile? FormCover { get; set; } // for upload
        public byte[]? Cover { get; set; } // for display
    }
}
