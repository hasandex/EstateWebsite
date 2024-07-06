namespace EstateWebsite.Repo.IRepo
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserFormVM>> GetUsers();
        int Count();
    }
}
