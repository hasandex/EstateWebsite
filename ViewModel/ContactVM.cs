namespace EstateWebsite.ViewModel
{
    public class ContactVM
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
