using Demo_MVP_QL.View.danhmuc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.Presenter.Danhmuc_Presenter
{
   
    public class Showdanhmuc
    {
        string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";
        IshowDanhmuc showDanhmuc;

        public Showdanhmuc(IshowDanhmuc showDanhmuc)
        {
            this.showDanhmuc = showDanhmuc;
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
                showDanhmuc.DanhmucData = dt;
                showDanhmuc.HienThi();
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
                comboBox.DisplayMember = "name"; // Display the category name in the ComboBox
                comboBox.ValueMember = "id";     // Use the ID as the value of the ComboBox items
                comboBox.DataSource = dt;
            }
        }
        //public void HienThiTenDanhmuccombobox(ComboBox comboBox)
        //{
        //    using (SqlConnection sqlcnt = new SqlConnection(sqlcon))
        //    {
        //        sqlcnt.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT [id], [name] FROM FoodCategory", sqlcnt);
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Bind the ComboBox with the DataTable
        //        comboBox.DisplayMember = "name"; // Display the category name in the ComboBox
        //        comboBox.ValueMember = "id";     // Use the ID as the value of the ComboBox items
        //        comboBox.DataSource = dt;
        //    }
        //}








    }
}
