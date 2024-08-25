using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAccessModuleService : IBaseService<AccessModule>
    {
        Task<List<AccessModule>> GetAllAsync();

        Task<AccessModule> GetAsync(int id);

        Task<bool> AddAsync(AccessModule model);

        Task<bool> UpdateAsync(AccessModule model);

        Task<bool> DeleteAsync(int id);
    }
}