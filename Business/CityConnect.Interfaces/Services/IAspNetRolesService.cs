using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetRolesService : IBaseService<AspNetRoles>
    {
        Task<List<AspNetRoles>> GetAllAsync();

        Task<AspNetRoles> GetAsync(int id);

        Task<bool> AddAsync(AspNetRoles model);

        Task<bool> UpdateAsync(AspNetRoles model);

        Task<bool> DeleteAsync(int id);
    }
}