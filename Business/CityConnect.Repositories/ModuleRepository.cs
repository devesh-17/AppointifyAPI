using CityConnect.Domain;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Repositories;

namespace CityConnect.Repositories
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(CityConnectContext context) : base(context)
        {
        }
    }
}