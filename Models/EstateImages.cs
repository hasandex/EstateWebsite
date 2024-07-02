namespace EstateWebsite.Models
{
    public class EstateImages
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        public Estate? Estate { get; set; }
    }
}
