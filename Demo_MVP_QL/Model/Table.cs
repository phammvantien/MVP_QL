using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.Model
{

    public class Table
    {
        string connectionString = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

    
        public DataTable GetDataFromDatabase()
        {
            string query = "SELECT id, name, status FROM TableFood";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }


        public DataTable GetFoodItemsForTable(int tableId)
        {
            string query = "SELECT Food.name, BillInfo.count, Food.price " +
                           "FROM BillInfo " +
                           "JOIN Bill ON BillInfo.idBill = Bill.id " +
                           "JOIN Food ON BillInfo.idFood = Food.id " +
                           "WHERE Bill.idTable = @TableId AND Bill.status = 0"; 

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableId", tableId);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }
        public void AddFoodToTable(int tableId, int foodId,int count)
        {
            string query = "INSERT INTO BillInfo (idBill, idFood, count) VALUES ((SELECT TOP 1 id FROM Bill WHERE idTable = @tableId AND status = 0), @foodId, @count)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId);
                command.Parameters.AddWithValue("@foodId", foodId);
                command.Parameters.AddWithValue("@count", count);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}