using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductManagementWebAPI.DTO
{
    public class LoginDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
