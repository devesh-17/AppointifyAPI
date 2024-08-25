using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AspNetUserRolesService : ServiceBase, IAspNetUserRolesService
    {
        public AspNetUserRolesService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AspNetUserRoles>> GetAllAsync()
        {
            var result = mapper.Map<List<AspNetUserRoles>>(await unitOfWork.AspNetUserRolesRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AspNetUserRoles> GetAsync(int id)
        {
            return mapper.Map<AspNetUserRoles>(await unitOfWork.AspNetUserRolesRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AspNetUserRoles model)
        {
            await unitOfWork.AspNetUserRolesRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AspNetUserRoles model)
        {
            var data = await unitOfWork.AspNetUserRolesRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AspNetUserRolesRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AspNetUserRolesRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AspNetUserRolesRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}