using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementWebAPI.Models
{
    public class CatagoryList
    {
        [Column(Order =0)]   
        [ForeignKey("Products")]
        public int PId { get; set; }
        [Column(Order =1)]
        [ForeignKey("Catagories")]
        public int CId { get; set; }

        public Products Products { get; set; }
        public Catagories Catagories { get; set; }
        public bool IsActive { get; set; }
    }
}
