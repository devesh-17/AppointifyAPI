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
    public class AspNetRoleClaimsController : BaseApiController
    {
        private readonly IHtmlLocalizer<AspNetRoleClaimsController> _localizer;
        private readonly IAspNetRoleClaimsService _AspNetRoleClaimsService;       
       
        public AspNetRoleClaimsController(IAspNetRoleClaimsService AspNetRoleClaimsService, IHtmlLocalizer<AspNetRoleClaimsController> localizer)
        {
            _AspNetRoleClaimsService = AspNetRoleClaimsService;            
            _localizer = localizer;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAll()
        {
            return await GetDataWithMessage(async () =>
            {
                var result = (await _AspNetRoleClaimsService.GetAllAsync());
                return Response(result, string.Empty);
            });
        }

        [HttpGet]
        public async Task<object> Get(int id)
        {
            return await GetDataWithMessage(async () =>
            {
                var result = await _AspNetRoleClaimsService.GetAsync(id);
                return Response(result, string.Empty);
            });
        }

        [HttpPost]
        public async Task<object> Post([FromBody] AspNetRoleClaims model)
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

        private async Task<Tuple<AspNetRoleClaims, string, DropMessageType>> AddAsync(AspNetRoleClaims model)
        {
            var flag = await _AspNetRoleClaimsService.AddAsync(model);
            if (flag)
            {
                return Response(model, _localizer["RecordAddSuccess"].Value.ToString());
            }
            return Response(model, _localizer["RecordNotAdded"].Value.ToString(), DropMessageType.Error);
        }

        private async Task<Tuple<AspNetRoleClaims, string, DropMessageType>> UpdateAsync(AspNetRoleClaims model)
        {
            var flag = await _AspNetRoleClaimsService.UpdateAsync(model);
            if (flag)
                return Response(model, _localizer["RecordUpdeteSuccess"].Value.ToString());
            return Response(model, _localizer["RecordNotUpdate"].Value.ToString(), DropMessageType.Error);
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            return await GetDataWithMessage(async () =>
            {
                var flag = await _AspNetRoleClaimsService.DeleteAsync(id);
                if (flag)
                    return Response(new BooleanResponseModel { Value = flag }, _localizer["RecordDeleteSuccess"].Value.ToString());
                return Response(new BooleanResponseModel { Value = flag }, _localizer["ReordNotDeleteSucess"].Value.ToString(), DropMessageType.Error);
            });
        }
    }
}