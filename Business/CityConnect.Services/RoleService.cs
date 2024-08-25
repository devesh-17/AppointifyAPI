using AutoMapper;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using CityConnect.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityConnect.Services
{
    public class RoleService : ServiceBase, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var result = mapper.Map<List<Role>>(await unitOfWork.RoleRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<Role> GetAsync(int id)
        {
            return mapper.Map<Role>(await unitOfWork.RoleRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(Role model)
        {
            await unitOfWork.RoleRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Role model)
        {
            var data = await unitOfWork.RoleRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.RoleRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.RoleRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.RoleRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

    }
}