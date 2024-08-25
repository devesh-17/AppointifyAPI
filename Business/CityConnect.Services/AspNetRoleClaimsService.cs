using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetRoleClaimsService : ServiceBase, IAspNetRoleClaimsService
    {
        public AspNetRoleClaimsService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetRoleClaims>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetRoleClaims>>(await unitOfWork.AspNetRoleClaimsRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetRoleClaims> GetAsync(int id)
        {
            return mapper.Map<AspNetRoleClaims>(await unitOfWork.AspNetRoleClaimsRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetRoleClaims model)
        {
            await unitOfWork.AspNetRoleClaimsRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetRoleClaims model)
        {
            var data = await unitOfWork.AspNetRoleClaimsRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetRoleClaimsRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetRoleClaimsRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetRoleClaimsRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}