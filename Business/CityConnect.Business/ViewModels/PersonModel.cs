using System.ComponentModel.DataAnnotations;

namespace CityConnect.Business.ViewModels
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Token { get; set; } 
        
        public int RoleId { get; set; }
    }
}