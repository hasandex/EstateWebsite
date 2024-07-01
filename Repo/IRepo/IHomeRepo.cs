
using EstateWebsite.ViewModel;

namespace EstateWebsite.Repo.IRepo
{
    public interface IHomeRepo
    {
        IEnumerable<Home> GetHomes();
        IEnumerable<HomeImages> GetAllImages(int homeId);
        Home GetById(int homeId);
        int Create(CreateHomeVM viewModel);
        int Update(UpdateHomeVM viewModel);
        int UpdateHomeImages(UpdateHomeImagesVM viewModel);
        int DeleteHomeImage(int homeId, string image);
    }
}
