using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementWebAPI.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }

        public string ProductGenericName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductTitle { get; set; }



        public int ProductWeight { get; set; }


        public int ProductPrice { get; set; }


        public string ImagePath { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public User Users { get; set; }



    }
}
