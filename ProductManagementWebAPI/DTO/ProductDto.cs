using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementWebAPI.DTO
{
    public class ProductDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Product Generic Name is required ")]
        public string ProductGenericName { get; set; }


        [Required(ErrorMessage = "Product Description is required ")]
        public string ProductDescription { get; set; }


        [Required(ErrorMessage = "Title is required ")]
        public string ProductTitle { get; set; }


        [Required(ErrorMessage = "Product Weight is required ")]
        public int ProductWeight { get; set; }


        [Required(ErrorMessage = "Product price is required ")]
        public int ProductPrice { get; set; }


        [Required(ErrorMessage = "Please Upload Image Name is required ")]

        public string ImagePath { get; set; }


        public int UserID { get; set; }
    }
}
