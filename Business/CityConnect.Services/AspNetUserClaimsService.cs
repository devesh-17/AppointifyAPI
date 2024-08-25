using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetUserClaimsService : ServiceBase, IAspNetUserClaimsService
    {
        public AspNetUserClaimsService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetUserClaims>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetUserClaims>>(await unitOfWork.AspNetUserClaimsRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetUserClaims> GetAsync(int id)
        {
            return mapper.Map<AspNetUserClaims>(await unitOfWork.AspNetUserClaimsRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetUserClaims model)
        {
            await unitOfWork.AspNetUserClaimsRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetUserClaims model)
        {
            var data = await unitOfWork.AspNetUserClaimsRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetUserClaimsRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetUserClaimsRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetUserClaimsRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}