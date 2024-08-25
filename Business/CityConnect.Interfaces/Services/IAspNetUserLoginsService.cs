using CityConnect.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityConnect.Interfaces.Services
{
    public interface IAspNetUserLoginsService : IBaseService<AspNetUserLogins>
    {
        Task<List<AspNetUserLogins>> GetAllAsync();

        Task<AspNetUserLogins> GetAsync(int id);

        Task<bool> AddAsync(AspNetUserLogins model);

        Task<bool> UpdateAsync(AspNetUserLogins model);

        Task<bool> DeleteAsync(int id);
    }
}