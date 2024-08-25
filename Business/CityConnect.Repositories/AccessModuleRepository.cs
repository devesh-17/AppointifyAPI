using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class AccessModuleRepository : BaseRepository<AccessModule>, IAccessModuleRepository
    {
        public AccessModuleRepository(CityConnectContext context) : base(context)
        {
        }
    }
}