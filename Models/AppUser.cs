namespace EstateWebsite.Models
{
    public class AppUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        [NotMapped]
        public IFormFile? ProfilePictureFile { get; set; }
        public byte[]? ProfilePicture { get; set; }

        //navigation
        public ICollection<Estate>? Estates { get; set; }
        //public ICollection<Comment>? Comment { get; set; }
    }

}
