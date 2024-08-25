using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class AccessModuleService : ServiceBase, IAccessModuleService
    {
        public AccessModuleService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<AccessModule>> GetAllAsync()
        {
            var result = mapper.Map<List<AccessModule>>(await unitOfWork.AccessModuleRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<AccessModule> GetAsync(int id)
        {
            return mapper.Map<AccessModule>(await unitOfWork.AccessModuleRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(AccessModule model)
        {
            await unitOfWork.AccessModuleRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(AccessModule model)
        {
            var data = await unitOfWork.AccessModuleRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.AccessModuleRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.AccessModuleRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.AccessModuleRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}