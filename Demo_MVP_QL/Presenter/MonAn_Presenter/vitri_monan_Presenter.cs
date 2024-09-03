using Demo_MVP_QL.View.Monan_View;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_MVP_QL.Presenter.MonAn_Presenter
{
    internal class vitri_monan_Presenter
    {
        private readonly Iselect_Monan _selectMonan;

        public vitri_monan_Presenter(Iselect_Monan selectMonan)
        {
            _selectMonan = selectMonan;
        }

        public void HienThiChiTietmonan()
        {
            int i = _selectMonan.SelectedRowIndexmonan;
            if (i >= 0)
            {
                try
                {
                    // Lấy giá trị từ DataGridView
                    _selectMonan.MonAnId = Convert.ToInt32(_selectMonan.DataGridViewMonan.Rows[i].Cells[0].Value);
                    _selectMonan.MonAnName = _selectMonan.DataGridViewMonan.Rows[i].Cells[1].Value.ToString();

                    // Chuyển từ tên danh mục sang IdCategory
                    string categoryName = _selectMonan.DataGridViewMonan.Rows[i].Cells[2].Value.ToString();
                    int idCategory = GetCategoryIdByName(categoryName);
                    _selectMonan.IdCategory = idCategory;

                    _selectMonan.MonAnPrice = Convert.ToSingle(_selectMonan.DataGridViewMonan.Rows[i].Cells[3].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy chi tiết món ăn: {ex.Message}");
                }
            }
        }

        private int GetCategoryIdByName(string categoryName)
        {
            using (SqlConnection sqlcnt = new SqlConnection(@"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;"))
            {
                sqlcnt.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT [id] 
                    FROM [QuanLyQuanAn].[dbo].[FoodCategory]
                    WHERE [name] = @categoryName", sqlcnt);
                cmd.Parameters.AddWithValue("@categoryName", categoryName);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Danh mục không tồn tại.");
                }
            }
        }
    }
}
