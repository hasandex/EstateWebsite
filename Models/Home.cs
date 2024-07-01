
namespace EstateWebsite.Models
{
    public class Home
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Area { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Price {  get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NFloor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NBedroom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NBath { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NLivingRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NReceptionRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NBalcone { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NGarage { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NKitchen { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NFoodRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int  NDepot { get; set; }
        public byte[] Cover { get; set; }
        public string? ExtraFeatures { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool ForRent { get; set; } = false;
        public bool ForSale { get; set; } = false;

        //navigation
        public ICollection<HomeImages>? HomeImages { get; set; }

    }
}
