using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementWebAPI.Models
{
    public class Catagories
    {


        [Key]
        public int Id { get; set; }

        public string CatagoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
