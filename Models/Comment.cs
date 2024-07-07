namespace EstateWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Estate? Estate { get; set; }
    }
}
