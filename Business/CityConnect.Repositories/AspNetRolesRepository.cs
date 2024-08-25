using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetRolesRepository : BaseRepository<AspNetRoles>, IAspNetRolesRepository
    {
        public AspNetRolesRepository(CityConnectContext context) : base(context)
        {
        }
    }
}