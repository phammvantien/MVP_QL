using System;
using System.Data;
using System.Data.SqlClient;
using Demo_MVP_QL.View.Banan_View;

namespace Demo_MVP_QL.Presenter.Banan_Presenter
{
    internal class AddBanan_Presenter
    {
        private readonly IAddBanan _view;
        private readonly string _connectionString = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public AddBanan_Presenter(IAddBanan view)
        {
            _view = view;
        }

        public void AddBanan()
        {
            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để thêm bàn mới
                    string query = "INSERT INTO TableFood (name, status) VALUES (@name, @status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", _view.BananName);
                        command.Parameters.AddWithValue("@status", _view.BananStatus ? "Có người" : "Trống");

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            _view.Message = "Thêm bàn mới thành công!";
                        }
                        else
                        {
                            _view.Message = "Thêm bàn mới thất bại.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    _view.Message = $"Lỗi: {ex.Message}";
                }
            }
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
