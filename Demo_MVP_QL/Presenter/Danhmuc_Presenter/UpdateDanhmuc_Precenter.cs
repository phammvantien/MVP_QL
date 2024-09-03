using Demo_MVP_QL.Model;
using Demo_MVP_QL.View.danhmuc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.Presenter.Danhmuc_Presenter
{
     class UpdateDanhmuc_Precenter
    {
        private readonly IUpdateDanhmuc _Updatedanhmuc;
        string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public UpdateDanhmuc_Precenter(IUpdateDanhmuc Updatedanhmuc)
        {
            _Updatedanhmuc = Updatedanhmuc;
        }

        public bool suadanhmuc()
        {
            danhmuc dm = new danhmuc();
            dm.danhmucID = _Updatedanhmuc.danhmucID;
            dm.danhmucName = _Updatedanhmuc.danhmucName;
            SqlConnection sqlcn = new SqlConnection(sqlcon);
            sqlcn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE   FoodCategory SET name=  @namee WHERE id=@id ;", sqlcn);
            cmd.Parameters.AddWithValue("@id", _Updatedanhmuc.danhmucID);
            cmd.Parameters.AddWithValue("@namee", _Updatedanhmuc.danhmucName);


            cmd.ExecuteNonQuery();
            sqlcn.Close();

            _Updatedanhmuc.Message = String.Format("sửa thành công");
            return true;

        }
        public void HienThiDanhmuc()
        {
            using (SqlConnection sqlcnt = new SqlConnection(sqlcon))
            {
                sqlcnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM FoodCategory", sqlcnt);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                _Updatedanhmuc.DanhmucData = dt;
                _Updatedanhmuc.HienThi();
            }
        }
        public void HienThiTenDanhmuc(ComboBox comboBox)
        {
            using (SqlConnection sqlcnt = new SqlConnection(sqlcon))
            {
                sqlcnt.Open();
                SqlCommand cmd = new SqlCommand("SELECT [id], [name] FROM FoodCategory", sqlcnt);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                // Bind the ComboBox with the DataTable
                comboBox.DisplayMember = "name"; // Show the name in the ComboBox
                comboBox.ValueMember = "id";     // Use the ID as the value of the ComboBox items
                comboBox.DataSource = dt;
            }
        }




    }
}
