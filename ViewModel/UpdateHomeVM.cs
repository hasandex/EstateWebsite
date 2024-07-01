namespace EstateWebsite.ViewModel
{
    public class UpdateHomeVM : BaseHomeVM
    {
        public int Id {  get; set; }
        public IFormFile? FormCover { get; set; } // for upload
        public byte[]? Cover { get; set; } // for display
    }
}
