using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetUserLoginsRepository : BaseRepository<AspNetUserLogins>, IAspNetUserLoginsRepository
    {
        public AspNetUserLoginsRepository(CityConnectContext context) : base(context)
        {
        }
    }
}