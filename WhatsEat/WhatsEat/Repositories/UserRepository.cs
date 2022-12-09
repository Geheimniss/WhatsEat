using WhatsEat.Areas.Identity.Data;
using WhatsEat.Core.Repositories;
using WhatsEat.DbContext;

namespace WhatsEat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUser(string id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Users.FirstOrDefault(u => u.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
             _context.Update(user);
             _context.SaveChanges();

             return user;
        }
    }
}
