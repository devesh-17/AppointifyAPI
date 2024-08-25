using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IRoleModuleService : IBaseService<RoleModule>
    {
        Task<List<RoleModule>> GetAllAsync();

        Task<RoleModule> GetAsync(int id);

        Task<bool> AddAsync(RoleModule model);

        Task<bool> UpdateAsync(RoleModule model);

        Task<bool> DeleteAsync(int id);
    }
}