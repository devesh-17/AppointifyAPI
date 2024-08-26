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
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IRoleModuleService _roleModuleService;

        public RoleAccessController(IRoleModuleService roleModuleService)
        {
            _roleModuleService = roleModuleService;
        }

    }
}