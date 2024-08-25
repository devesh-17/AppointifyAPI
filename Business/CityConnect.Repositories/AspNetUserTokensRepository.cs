using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AspNetUserTokensRepository : BaseRepository<AspNetUserTokens>, IAspNetUserTokensRepository
    {
        public AspNetUserTokensRepository(CityConnectContext context) : base(context)
        {
        }
    }
}