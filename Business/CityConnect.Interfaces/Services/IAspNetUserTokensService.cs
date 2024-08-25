using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetUserTokensService : IBaseService<AspNetUserTokens>
    {
        Task<List<AspNetUserTokens>> GetAllAsync();

        Task<AspNetUserTokens> GetAsync(int id);

        Task<bool> AddAsync(AspNetUserTokens model);

        Task<bool> UpdateAsync(AspNetUserTokens model);

        Task<bool> DeleteAsync(int id);
    }
}