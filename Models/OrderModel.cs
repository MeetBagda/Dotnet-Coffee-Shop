using System.ComponentModel.DataAnnotations;

namespace coffee_shop.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }

        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Payment Mode is required.")]
        [StringLength(50, ErrorMessage = "Payment Mode cannot be longer than 50 characters.")]
        public string PaymentMode { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0.")]
        public decimal? TotalAmount { get; set; }

        [Required(ErrorMessage = "Shipping Address is required.")]
        [StringLength(250, ErrorMessage = "Shipping Address cannot be longer than 250 characters.")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }
    }
}
