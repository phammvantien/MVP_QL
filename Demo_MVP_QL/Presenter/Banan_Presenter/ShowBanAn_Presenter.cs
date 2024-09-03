using Demo_MVP_QL.View.Banan_View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.Presenter.Banan_Presenter
{
    internal class ShowBanAn_Presenter
    {
        private readonly IShowBanan _view;
        private readonly string _connectionString = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public ShowBanAn_Presenter(IShowBanan view )
        {
            _view = view;
        }



        public void ShowBanan()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Truy vấn lấy tất cả dữ liệu từ bảng TableFood
                    string query = "SELECT id, name, status FROM TableFood";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Thay đổi tên cột trong DataTable
                        dt.Columns["id"].ColumnName = "Mã";
                        dt.Columns["name"].ColumnName = "Tên";
                        dt.Columns["status"].ColumnName = "Trạng Thái";

                        // Liên kết DataGridView với DataTable
                        _view.DataGridViewBanan.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    _view.Message = $"Lỗi: {ex.Message}";
                }
            }
        }



    }
}