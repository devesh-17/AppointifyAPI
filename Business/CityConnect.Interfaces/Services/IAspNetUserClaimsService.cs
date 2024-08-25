using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetUserClaimsService : IBaseService<AspNetUserClaims>
    {
        Task<List<AspNetUserClaims>> GetAllAsync();

        Task<AspNetUserClaims> GetAsync(int id);

        Task<bool> AddAsync(AspNetUserClaims model);

        Task<bool> UpdateAsync(AspNetUserClaims model);

        Task<bool> DeleteAsync(int id);
    }
}