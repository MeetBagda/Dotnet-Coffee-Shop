using System.ComponentModel.DataAnnotations;

namespace coffee_shop.Models
{
    public class BillModel
    {
        public int BillID { get; set; }

        [Required(ErrorMessage = "Bill Number is required.")]
        [StringLength(100, ErrorMessage = "Bill Number cannot be longer than 100 characters.")]
        public string BillNumber { get; set; }

        [Required(ErrorMessage = "Bill Date is required.")]
        public DateTime BillDate { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Total Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than 0.")]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Discount cannot be negative.")]
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "Net Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Net Amount must be greater than 0.")]
        public decimal NetAmount { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserID { get; set; }

        public int CustomerID { get; set; }
    }

}
