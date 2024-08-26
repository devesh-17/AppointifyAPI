using CityConnect.Business.Helpers;
using CityConnect.Business.ViewModels;
using CityConnect.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CityConnect.Domain.Models;

namespace CityConnect.Controllers
{
    public class LoginController : BaseController
    {
        private readonly new SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser personModel)
        {
            var result = await DoActionForPost<LoginResponseModel>(personModel, "Person/Login");
            if (!string.IsNullOrEmpty(result.Data.Token))
            {
                await _signInManager.SignInAsync(result.Data.ApplicationUser, isPersistent: true);

                MemoryCacheHelper.memoryCache.Set(Constant.Memory_UserRoles, result.Data.roleModuleModel);

                SessionHelper.Set(HttpContext, Constant.AppicationUserData, result.Data);
                return PostCompleteRedirect(Url.Action("Index", "Person"));
            }
            return PostFailed();
        }

        [HttpPost]
        public async Task<PostJsonResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var sessionClear = SessionHelper.Remove(HttpContext);
            if (!sessionClear)
            {
                return PostFailed();
            }
            return PostCompleteRedirect(Url.Action("Index", "Login"));
        }
    }
}