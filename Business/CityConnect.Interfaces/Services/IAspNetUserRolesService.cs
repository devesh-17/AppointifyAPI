using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetUserRolesService : IBaseService<AspNetUserRoles>
    {
        Task<List<AspNetUserRoles>> GetAllAsync();

        Task<AspNetUserRoles> GetAsync(int id);

        Task<bool> AddAsync(AspNetUserRoles model);

        Task<bool> UpdateAsync(AspNetUserRoles model);

        Task<bool> DeleteAsync(int id);
    }
}