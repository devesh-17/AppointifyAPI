using CityConnect.Business.Enums.General;
using CityConnect.Business.ViewModels.General;
using CityConnect.Domain;
using CityConnect.Interfaces.Background;
using CityConnect.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using CityConnect.Business.ViewModels;
using AAT.API.Helpers;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Identity;
using CityConnect.Pdf.Models;
using CityConnect.Business.Helpers;
using CityConnect.Pdf;
using CityConnect.Domain.Models;
using CityConnect.API.Filters;
using Org.BouncyCastle.Math.EC.Rfc7748;
using CityConnect.Business.ViewModels.Organization;
using CityConnect.Services;

namespace CityConnect.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RoleAccessController : BaseApiController
    {
       private readonly IHtmlLocalizer<PersonController> _localizer;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleModuleService _roleModuleService;

        public RoleAccessController(IHtmlLocalizer<PersonController> localizer,IRoleModuleService roleModuleService)
        {
            _localizer = localizer;
            _roleModuleService = roleModuleService;
        }

        #region POST/PUT
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Post([FromBody] RoleModuleDetailsModel roleModuleModel)
        {
            return await GetDataWithMessage(async () =>
            {
                if (ModelState.IsValid && roleModuleModel != null)
                {
                    return roleModuleModel.Id > 0 ? await UpdateAsync(roleModuleModel) : await AddAsync(roleModuleModel);
                }
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                return Response(roleModuleModel, string.Join(",", errors), DropMessageType.Error);
            });
        }
        private async Task<Tuple<RoleModuleDetailsModel, string, DropMessageType>> AddAsync(RoleModuleDetailsModel roleModuleModel)
        {
            var flag = await _roleModuleService.AddAsync(roleModuleModel);
            if (flag)
            {
                return Response(roleModuleModel, _localizer["RecordAddSuccess"].Value.ToString());
            }
            return Response(roleModuleModel, _localizer["RecordNotAdded"].Value.ToString(), DropMessageType.Error);
        }

        private async Task<Tuple<RoleModuleDetailsModel, string, DropMessageType>> UpdateAsync(RoleModuleDetailsModel roleModuleModel)
        {
            var flag = await _roleModuleService.UpdateAsync(roleModuleModel);
            if (flag)
                return Response(roleModuleModel, _localizer["RecordUpdeteSuccess"].Value.ToString());
            return Response(roleModuleModel, _localizer["RecordNotUpdate"].Value.ToString(), DropMessageType.Error);
        }
        #endregion
    }
}