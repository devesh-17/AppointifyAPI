using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class ModuleService : ServiceBase, IModuleService
    {
        public ModuleService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<Module>> GetAllAsync()
        {
            var result = mapper.Map<List<Module>>(await unitOfWork.ModuleRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<Module> GetAsync(int id)
        {
            return mapper.Map<Module>(await unitOfWork.ModuleRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(Module model)
        {
            await unitOfWork.ModuleRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Module model)
        {
            var data = await unitOfWork.ModuleRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.ModuleRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.ModuleRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.ModuleRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}