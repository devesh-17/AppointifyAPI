using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class RoleModuleRepository : BaseRepository<RoleModule>, IRoleModuleRepository
    {
        public RoleModuleRepository(CityConnectContext context) : base(context)
        {
        }
    }
}