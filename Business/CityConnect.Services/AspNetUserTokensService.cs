using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetUserTokensService : ServiceBase, IAspNetUserTokensService
    {
        public AspNetUserTokensService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetUserTokens>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetUserTokens>>(await unitOfWork.AspNetUserTokensRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetUserTokens> GetAsync(int id)
        {
            return mapper.Map<AspNetUserTokens>(await unitOfWork.AspNetUserTokensRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetUserTokens model)
        {
            await unitOfWork.AspNetUserTokensRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetUserTokens model)
        {
            var data = await unitOfWork.AspNetUserTokensRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetUserTokensRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetUserTokensRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetUserTokensRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}