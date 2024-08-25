using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetUserRolesRepository : BaseRepository<AspNetUserRoles>, IAspNetUserRolesRepository
    {
        public AspNetUserRolesRepository(CityConnectContext context) : base(context)
        {
        }
    }
}