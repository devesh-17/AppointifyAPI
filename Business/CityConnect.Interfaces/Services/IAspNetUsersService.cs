using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetUsersService : IBaseService<AspNetUsers>
    {
        Task<List<AspNetUsers>> GetAllAsync();

        Task<AspNetUsers> GetAsync(int id);

        Task<bool> AddAsync(AspNetUsers model);

        Task<bool> UpdateAsync(AspNetUsers model);

        Task<bool> DeleteAsync(int id);
    }
}