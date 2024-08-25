using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetRoleClaimsRepository : BaseRepository<AspNetRoleClaims>, IAspNetRoleClaimsRepository
    {
        public AspNetRoleClaimsRepository(CityConnectContext context) : base(context)
        {
        }
    }
}