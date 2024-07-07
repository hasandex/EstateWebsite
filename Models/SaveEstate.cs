namespace EstateWebsite.Models
{
    public class SaveEstate
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EstateId { get; set; }
        public Estate? Estate { get; set; }
        public AppUser? Users { get; set; }
    }
}
