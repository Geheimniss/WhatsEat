using WhatsEat.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace WhatsEat.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
