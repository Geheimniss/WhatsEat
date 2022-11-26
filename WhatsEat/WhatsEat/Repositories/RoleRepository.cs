using WhatsEat.Areas.Identity.Data;
using WhatsEat.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace WhatsEat.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
