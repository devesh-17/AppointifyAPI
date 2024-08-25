using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetUsersRepository : BaseRepository<AspNetUsers>, IAspNetUsersRepository
    {
        public AspNetUsersRepository(CityConnectContext context) : base(context)
        {
        }
    }
}