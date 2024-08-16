using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

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
    }
}
