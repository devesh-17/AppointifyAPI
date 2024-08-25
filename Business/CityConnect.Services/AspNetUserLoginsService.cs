using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetUserLoginsService : ServiceBase, IAspNetUserLoginsService
    {
        public AspNetUserLoginsService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetUserLogins>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetUserLogins>>(await unitOfWork.AspNetUserLoginsRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetUserLogins> GetAsync(int id)
        {
            return mapper.Map<AspNetUserLogins>(await unitOfWork.AspNetUserLoginsRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetUserLogins model)
        {
            await unitOfWork.AspNetUserLoginsRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetUserLogins model)
        {
            var data = await unitOfWork.AspNetUserLoginsRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetUserLoginsRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetUserLoginsRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetUserLoginsRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}