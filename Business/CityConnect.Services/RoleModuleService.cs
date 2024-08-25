using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class RoleModuleService : ServiceBase, IRoleModuleService
    {
        public RoleModuleService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<RoleModule>> GetAllAsync()
        {
            var result = mapper.Map<List<RoleModule>>(await unitOfWork.RoleModuleRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<RoleModule> GetAsync(int id)
        {
            return mapper.Map<RoleModule>(await unitOfWork.RoleModuleRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(RoleModule model)
        {
            await unitOfWork.RoleModuleRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(RoleModule model)
        {
            var data = await unitOfWork.RoleModuleRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.RoleModuleRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.RoleModuleRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.RoleModuleRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}