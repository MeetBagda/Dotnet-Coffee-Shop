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
        public string GSTNo { get; set; }

        [Required(ErrorMessage = "City Name is required.")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pin Code must be a 6-digit number.")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Net Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Net Amount must be greater than 0.")]
        public decimal NetAmount { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public UserDropdownModel User { get; set; }
    }

}
