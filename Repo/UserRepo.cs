using Microsoft.AspNetCore.Identity;

namespace EstateWebsite.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        public UserRepo(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<UserFormVM>> IUserRepo.GetUsers()
        {
            var users = await _userManager?.Users.ToListAsync();
            if (!users.Any())
            {
                return null;
            }
            var userFormVM = new List<UserFormVM>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userForm = new UserFormVM
                {
                    Id = user.Id,
                    FirstName = user.FName,
                    LastName = user.FName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles,
                };
                userFormVM.Add(userForm);
            }
            return userFormVM;
        }
    }
}
