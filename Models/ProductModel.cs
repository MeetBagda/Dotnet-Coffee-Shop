using System.ComponentModel.DataAnnotations;

namespace coffee_shop.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product Price must be greater than 0.")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Product Code is required.")]
        [StringLength(100, ErrorMessage = "Product Code cannot be longer than 100 characters.")]
        public string ProductCode { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }
    }
}
