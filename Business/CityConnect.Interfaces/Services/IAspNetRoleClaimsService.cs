using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetRoleClaimsService : IBaseService<AspNetRoleClaims>
    {
        Task<List<AspNetRoleClaims>> GetAllAsync();

        Task<AspNetRoleClaims> GetAsync(int id);

        Task<bool> AddAsync(AspNetRoleClaims model);

        Task<bool> UpdateAsync(AspNetRoleClaims model);

        Task<bool> DeleteAsync(int id);
    }
}