
namespace EstateWebsite.Repo
{
    public class SaveProperty : ISaveProperty
    {
        private readonly AppDbContext _context;
        private readonly IEstateRepo _estateRepo;
        private readonly IUserService _userService;

        public SaveProperty(AppDbContext context, IEstateRepo estateRepo, IUserService userService)
        {
            _context = context;
            _estateRepo = estateRepo;
            _userService = userService;
        }

        public IEnumerable<SaveEstate> GetAllSavedEstates(string userId)
        {
            return _context.SaveEstates?
            .Include(se => se.Estate)
            .Where(se => se.UserId == userId)
            .ToList();
        }

        //to check if the user save this estate or not, if he saved it then return it
        public SaveEstate GetByIdAndUser(int estateId , string userId)
        {
            var result = _context.SaveEstates?
                .Where(se => se.UserId == userId && se.EstateId == estateId)
                .FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public int Remove(int estateId)
        {
            //check if the estate is exsited
            var estate = _estateRepo.GetById(estateId);
            if (estate == null)
            {
                return 0;
            }
            //make sure the user has saved this estate before, so we can remove it
            var result = GetByIdAndUser(estateId, _userService.GetUserId());
            if (result != null)
            {
                _context.SaveEstates.Remove(result);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int Save(int estateId)
        {
            //check if the estate is exsited
            var estate = _estateRepo.GetById(estateId);
            if (estate == null)
            {
                return 0;
            }
            //create object from class SaveEstate handling the estateId and UserId, and then add it to the database
            var saveEstate = new SaveEstate()
            {
                EstateId = estate.Id,
                UserId = estate.UserId,
            };
            _context.SaveEstates.Add(saveEstate);
            _context.SaveChanges();
            return 1;
        }
    }
}
