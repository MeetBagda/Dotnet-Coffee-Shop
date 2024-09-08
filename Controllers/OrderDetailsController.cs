using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using coffee_shop.Models;

namespace coffee_shop.Controllers
{
    public class OrderDetailsController : Controller
    {
        private IConfiguration configuration;

        public OrderDetailsController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult OrderDetailsList()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spOrderDetails_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }

        public IActionResult OrderDetailsDelete(int orderDetailId)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spOrderDetails_Delete";
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                Console.WriteLine(ex.ToString());
            }
            return RedirectToAction("OrderDetailsList");
        }

        public IActionResult OrderDetailSave(OrderDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("OrderDetail");
            }
            return View("OrderDetailForm", model);
        }

        public IActionResult OrderDetailForm()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");

            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            sqlConnection1.Open();
            SqlCommand command1 = sqlConnection1.CreateCommand();
            command1.CommandType = System.Data.CommandType.StoredProcedure;
            command1.CommandText = "PR_Product_DropDown";
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(reader1);
            List<ProductDropDownModel> productList = new List<ProductDropDownModel>();
            foreach (DataRow data in dataTable1.Rows)
            {
                ProductDropDownModel productDropDownModel = new ProductDropDownModel();
                productDropDownModel.ProductID = Convert.ToInt32(data["ProductID"]);
                productDropDownModel.ProductName = data["ProductName"].ToString();
                productList.Add(productDropDownModel);
            }
            ViewBag.Products = productList;

            SqlConnection sqlConnection2 = new SqlConnection(connectionString);
            sqlConnection2.Open();
            SqlCommand command2 = sqlConnection1.CreateCommand();
            command2.CommandType = System.Data.CommandType.StoredProcedure;
            command2.CommandText = "spUsers_SelectDropdown";
            SqlDataReader reader2 = command2.ExecuteReader();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(reader2);
            List<UserDropDownModel> userList = new List<UserDropDownModel>();
            foreach (DataRow data in dataTable2.Rows)
            {
                UserDropDownModel userDropDownModel = new UserDropDownModel();
                userDropDownModel.UserID = Convert.ToInt32(data["UserID"]);
                userDropDownModel.UserName = data["UserName"].ToString();
                userList.Add(userDropDownModel);
            }

            ViewBag.Users = userList;


            SqlConnection sqlConnection3 = new SqlConnection(connectionString);
            sqlConnection3.Open();
            SqlCommand command3 = sqlConnection1.CreateCommand();
            command3.CommandType = System.Data.CommandType.StoredProcedure;
            command3.CommandText = "spOrders_SelectDropdown";
            SqlDataReader reader3 = command3.ExecuteReader();
            DataTable dataTable3 = new DataTable();
            dataTable3.Load(reader3);
            List<OrderDropDownModel> orderList = new List<OrderDropDownModel>();
            foreach (DataRow data in dataTable3.Rows)
            {
                OrderDropDownModel orderDropDownModel = new OrderDropDownModel();
                orderDropDownModel.OrderID = Convert.ToInt32(data["OrderID"]);
                orderDropDownModel.OrderCode = data["OrderCode"].ToString();
                orderList.Add(orderDropDownModel);
            }

            ViewBag.Orders = orderList;



            return View();
        }
    }
}
