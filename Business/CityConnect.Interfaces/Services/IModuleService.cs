using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IModuleService : IBaseService<Module>
    {
        Task<List<Module>> GetAllAsync();

        Task<Module> GetAsync(int id);

        Task<bool> AddAsync(Module model);

        Task<bool> UpdateAsync(Module model);

        Task<bool> DeleteAsync(int id);
    }
}