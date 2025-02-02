﻿
using EstateWebsite.ViewModel;

namespace EstateWebsite.Repo.IRepo
{
    public interface IEstateRepo
    {
        IEnumerable<Estate> GetEstates();
        IEnumerable<Estate> GetEstates(string userId);
        IEnumerable<EstateImages> GetAllImages(int estateId);
        Estate GetById(int estateId);
        int Create(CreateEstateVM viewModel);
        int Update(UpdateEstateVM viewModel);
        int Delete(int estateId);
        int UpdateEstateImages(UpdateEstateImagesVM viewModel);
        int DeleteEstateImage(int estateId, string image);
        IEnumerable<Estate> GetByCategory(Category category);
        //IEnumerable<Estate> GetEstateDelegate(Func<Estate, bool> filter);
        IEnumerable<IGrouping<Category, Estate>> GroupByCategory();
        IEnumerable<Estate> GetEstateForRent();
        IEnumerable<Estate> GetEstateForSell();
        IEnumerable<Estate> SearchByName(string searchName);
        int CountEstates(IEnumerable<Estate> estates);
    }
}
