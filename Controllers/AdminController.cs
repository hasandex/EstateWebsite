using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstateWebsite.Controllers
{
    [Authorize(Roles = ClsRoles.roleAdmin)]
    public class AdminController : Controller
    {
        private readonly IEstateRepo _estateRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IEstateRepo estateRepo, IMapper mapper,
            IUserService userService, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, IUserRepo userRepo)
        {
            _estateRepo = estateRepo;
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            var estates = _estateRepo.GetEstates();
            return View(estates);
        }
        public async Task<IActionResult> DisplayUsers()
        {
            var users = await _userRepo.GetUsers();
            ViewBag.Users = "Users";
            return View(users);
        }
        public async Task<IActionResult> addRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            var allRoles = await _roleManager.Roles.ToListAsync();
            if (allRoles != null)
            {
                var roleList = allRoles.Select(r => new RoleVM()
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRoles.Any(x => x == r.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = userId;
                return View(roleList);
            }
            else
                return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId, string jsonRoles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            List<RoleVM> myRoles =
                JsonConvert.DeserializeObject<List<RoleVM>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.roleName.Trim());
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
