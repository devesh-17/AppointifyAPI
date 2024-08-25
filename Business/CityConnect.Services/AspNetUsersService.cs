using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetUsersService : ServiceBase, IAspNetUsersService
    {
        public AspNetUsersService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetUsers>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetUsers>>(await unitOfWork.AspNetUsersRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetUsers> GetAsync(int id)
        {
            return mapper.Map<AspNetUsers>(await unitOfWork.AspNetUsersRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetUsers model)
        {
            await unitOfWork.AspNetUsersRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetUsers model)
        {
            var data = await unitOfWork.AspNetUsersRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetUsersRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetUsersRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetUsersRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}