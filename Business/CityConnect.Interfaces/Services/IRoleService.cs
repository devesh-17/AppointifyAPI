using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        Task<List<Role>> GetAllAsync();

        Task<Role> GetAsync(int id);

        Task<bool> AddAsync(Role model);

        Task<bool> UpdateAsync(Role model);

        Task<bool> DeleteAsync(int id);
    }
}