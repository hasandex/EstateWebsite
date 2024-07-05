using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateWebsite.ViewModel
{
    public class BaseEstateVM
    {
        public string Name { get; set; }
        public string OwnerName { get; set; }
        [Phone]
        public string OwnerPhone { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Area { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NFloor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBedroom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBath { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NLivingRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NReceptionRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NBalcone { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NGarage { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NKitchen { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NFoodRoom { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int NDepot { get; set; }
        public string? ExtraFeatures { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool ForRent { get; set; } = false;
        public bool ForSale { get; set; } = false;
        public Category Category { get; set; }
        public MethodPay MethodPay { get; set; }
        public LegalType LegalType { get; set; }
        public CompleteBuildingState CompleteBuildingState { get; set; }
        public IEnumerable<SelectListItem> SelectCategory { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> SelectMethodPay { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> SelectLegalType { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> SelectCompleteBuildingState { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
