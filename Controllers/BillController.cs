using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using coffee_shop.Models;

namespace coffee_shop.Controllers
{
    public class BillController : Controller
    {
        private readonly IConfiguration configuration;

        public BillController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public IActionResult BillList()
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "spBill_SelectAll";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                return View(dataTable);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while retrieving the bill list.";
                return View("Error");
            }
        }

        public IActionResult BillDelete(int billId)
        {
            try
            {
                string connectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spBill_Delete";
                command.Parameters.AddWithValue("@BillID", billId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                Console.WriteLine(ex.ToString());
            }
            return RedirectToAction("BillList");
        }

        public IActionResult BillsForm()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            sqlConnection1.Open();
            SqlCommand command1 = sqlConnection1.CreateCommand();
            command1.CommandType = System.Data.CommandType.StoredProcedure;
            command1.CommandText = "spUsers_SelectDropdown";
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable dataTable1 = new DataTable();
            dataTable1.Load(reader1);
            List<UserDropDownModel> userList = new List<UserDropDownModel>();
            foreach (DataRow data in dataTable1.Rows)
            {
                UserDropDownModel userDropDownModel = new UserDropDownModel();
                userDropDownModel.UserID = Convert.ToInt32(data["UserID"]);
                userDropDownModel.UserName = data["UserName"].ToString();
                userList.Add(userDropDownModel);
            }

            ViewBag.Users = userList;

            SqlConnection sqlConnection2 = new SqlConnection(connectionString);
            sqlConnection2.Open();
            SqlCommand command2 = sqlConnection1.CreateCommand();
            command2.CommandType = System.Data.CommandType.StoredProcedure;
            command2.CommandText = "spOrders_SelectDropdown";
            SqlDataReader reader2 = command2.ExecuteReader();
            DataTable dataTable2 = new DataTable();
            dataTable2.Load(reader2);
            List<OrderDropDownModel> orderList = new List<OrderDropDownModel>();
            foreach (DataRow data in dataTable2.Rows)
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
