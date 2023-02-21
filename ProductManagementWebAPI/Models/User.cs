using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagementWebAPI.Models
{
    public class User
    {
        
            [Key]
            public int Id { get; set; }


            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public string Gender { get; set; }

            public string Email_Id { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }
            public string Roles { get; set; }
            
        
    }
}
