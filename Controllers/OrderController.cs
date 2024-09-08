using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using coffee_shop.Models;

namespace coffee_shop.Controllers
{
    public class OrderController : Controller
    {
        private IConfiguration configuration;

        public OrderController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult OrderList()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spOrder_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }

        public IActionResult OrderDelete(int orderId)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spOrder_Delete";
                command.Parameters.AddWithValue("@OrderID", orderId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                Console.WriteLine(ex.ToString());
            }
            return RedirectToAction("OrderList");
        }

        public IActionResult OrderForm()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            sqlConnection1.Open();
            SqlCommand command1 = sqlConnection1.CreateCommand();
            command1.CommandType = System.Data.CommandType.StoredProcedure;
            command1.CommandText = "sps_SelectDropdown";
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(reader1);
            List<CustomerDropDownModel> customerList = new List<CustomerDropDownModel>();
            foreach (DataRow data in dataTable1.Rows)
            {
                CustomerDropDownModel customerDropDownModel = new CustomerDropDownModel();
                customerDropDownModel.CustomerID = Convert.ToInt32(data["CustomerID"]);
                customerDropDownModel.CustomerName = data["CustomerName"].ToString();
                customerList.Add(customerDropDownModel);
            }
            ViewBag.Customers = customerList;

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

            return View();

        }
    }
}
