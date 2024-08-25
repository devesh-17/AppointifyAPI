using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetRolesService : ServiceBase, IAspNetRolesService
    {
        public AspNetRolesService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetRoles>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetRoles>>(await unitOfWork.AspNetRolesRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetRoles> GetAsync(int id)
        {
            return mapper.Map<AspNetRoles>(await unitOfWork.AspNetRolesRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetRoles model)
        {
            await unitOfWork.AspNetRolesRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetRoles model)
        {
            var data = await unitOfWork.AspNetRolesRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetRolesRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetRolesRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetRolesRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}