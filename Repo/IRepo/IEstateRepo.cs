
using EstateWebsite.ViewModel;

namespace EstateWebsite.Repo.IRepo
{
    public interface IEstateRepo
    {
        IEnumerable<Estate> GetEstates();
        IEnumerable<EstateImages> GetAllImages(int estateId);
        Estate GetById(int estateId);
        int Create(CreateEstateVM viewModel);
        int Update(UpdateEstateVM viewModel);
        int UpdateEstateImages(UpdateEstateImagesVM viewModel);
        int DeleteEstateImage(int estateId, string image);
    }
}
