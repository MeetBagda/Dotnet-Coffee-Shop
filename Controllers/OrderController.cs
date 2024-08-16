using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

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
    }
}
