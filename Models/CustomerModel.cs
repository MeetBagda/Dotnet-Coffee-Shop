using System.ComponentModel.DataAnnotations;

namespace coffee_shop.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        [StringLength(100, ErrorMessage = "Customer Name cannot be longer than 100 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Home Address is required.")]
        [StringLength(250, ErrorMessage = "Home Address cannot be longer than 250 characters.")]
        public string HomeAddress { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile No is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile No must be a 10-digit number.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "GST No is required.")]
        [StringLength(15, ErrorMessage = "GST Number cannot be longer than 15 characters")]
        public string GSTNo { get; set; }

        [Required(ErrorMessage = "City Name is required.")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pin Code must be 6 characters long")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Net Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Net Amount must be a positive number")]
        public decimal NetAmount { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }
    }

    public class CustomerDropDownModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }

}
