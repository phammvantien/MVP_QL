using Demo_MVP_QL.View.danhmuc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_MVP_QL.Model;
using Demo_MVP_QL.Presenter.Danhmuc_Presenter;
using System.Windows.Forms;

namespace Demo_MVP_QL.Presenter
{
     class AddDanhmuc_Precenter
    {
        IAddDanhmuc addDanhmuc; // khai báo 
       
        string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public AddDanhmuc_Precenter(IAddDanhmuc addDanhmuc)
        {
            this.addDanhmuc = addDanhmuc;
        }

        public bool adddanhmuc()
        {
            danhmuc dm = new danhmuc();
            dm.danhmucID=addDanhmuc.danhmucID;
            dm.danhmucName=addDanhmuc.danhmucName;
            SqlConnection sqlcn = new SqlConnection(sqlcon);
            sqlcn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO  FoodCategory (name) VALUES ( @namee ) ;", sqlcn);
           
            cmd.Parameters.AddWithValue("@namee", addDanhmuc.danhmucName);


            cmd.ExecuteNonQuery();
            sqlcn.Close();
         
            addDanhmuc.Message = String.Format("Thêm thành công");
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
                addDanhmuc.DanhmucData = dt;
                addDanhmuc.HienThi();
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
