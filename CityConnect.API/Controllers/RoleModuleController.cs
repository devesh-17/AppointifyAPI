using CityConnect.Business.Enums.General;
using CityConnect.Business.ViewModels.General;
using CityConnect.Domain.Models;
using CityConnect.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CityConnect.API.Controllers
{
    //[Authorize]    
    [Route("api/[controller]")]
    public class RoleModuleController : BaseApiController
    {
        private readonly IHtmlLocalizer<RoleModuleController> _localizer;
        private readonly IRoleModuleService _RoleModuleService;       
       
        public RoleModuleController(IRoleModuleService RoleModuleService, IHtmlLocalizer<RoleModuleController> localizer)
        {
            _RoleModuleService = RoleModuleService;            
            _localizer = localizer;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAll()
        {
            return await GetDataWithMessage(async () =>
            {
                var result = (await _RoleModuleService.GetAllAsync());
                return Response(result, string.Empty);
            });
        }

        [HttpGet]
        public async Task<object> Get(int id)
        {
            return await GetDataWithMessage(async () =>
            {
                var result = await _RoleModuleService.GetAsync(id);
                return Response(result, string.Empty);
            });
        }

        [HttpPost]
        public async Task<object> Post([FromBody] RoleModule model)
        {
            return await GetDataWithMessage(async () =>
            {
                if (ModelState.IsValid && model != null)
                {
                    return model.Id <= 0 ? await AddAsync(model) : await UpdateAsync(model);
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                return Response(model, string.Join(",", errors), DropMessageType.Error);
            });
        }

        private async Task<Tuple<RoleModule, string, DropMessageType>> AddAsync(RoleModule model)
        {
            var flag = await _RoleModuleService.AddAsync(model);
            if (flag)
            {
                return Response(model, _localizer["RecordAddSuccess"].Value.ToString());
            }
            return Response(model, _localizer["RecordNotAdded"].Value.ToString(), DropMessageType.Error);
        }

        private async Task<Tuple<RoleModule, string, DropMessageType>> UpdateAsync(RoleModule model)
        {
            var flag = await _RoleModuleService.UpdateAsync(model);
            if (flag)
                return Response(model, _localizer["RecordUpdeteSuccess"].Value.ToString());
            return Response(model, _localizer["RecordNotUpdate"].Value.ToString(), DropMessageType.Error);
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            return await GetDataWithMessage(async () =>
            {
                var flag = await _RoleModuleService.DeleteAsync(id);
                if (flag)
                    return Response(new BooleanResponseModel { Value = flag }, _localizer["RecordDeleteSuccess"].Value.ToString());
                return Response(new BooleanResponseModel { Value = flag }, _localizer["ReordNotDeleteSucess"].Value.ToString(), DropMessageType.Error);
            });
        }
    }
}