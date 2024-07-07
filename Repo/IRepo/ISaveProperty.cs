namespace EstateWebsite.Repo.IRepo
{
    public interface ISaveProperty
    {
        int Save(int estateId);
        int Remove(int estateId);
        SaveEstate GetByIdAndUser(int estateId , string userId);
        IEnumerable<SaveEstate> GetAllSavedEstates(string userId);
    }
}
