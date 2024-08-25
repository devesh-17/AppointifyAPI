using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetUserClaimsRepository : BaseRepository<AspNetUserClaims>, IAspNetUserClaimsRepository
    {
        public AspNetUserClaimsRepository(CityConnectContext context) : base(context)
        {
        }
    }
}