using CityConnect.Business.ViewModels.Account;
using CityConnect.Business.ViewModels.Organization;
using CityConnect.Domain.Models;
using System.Collections.Generic;

namespace CityConnect.Business.ViewModels
{
    public class LoginResponseModel
    {        
        public ApplicationUser ApplicationUser { get; set; }

        public string Token { get; set; }        

        public List<RoleModuleModel> roleModuleModel { get; set; }
    }
}