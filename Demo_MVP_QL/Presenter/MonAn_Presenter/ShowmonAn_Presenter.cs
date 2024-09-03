using Demo_MVP_QL.View.danhmuc;
using System;
using System.Data;
using System.Data.SqlClient;
using Demo_MVP_QL.View.Monan_View;

namespace Demo_MVP_QL.Presenter.MonAn_Presenter
{
    internal class ShowmonAn_Presenter
    {
        string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";
        Ishowmonan showmonan;

        public ShowmonAn_Presenter(Ishowmonan showmonan)
        {
            this.showmonan = showmonan;
        }

        public void HienThiMonan()
        {
            using (SqlConnection sqlcnt = new SqlConnection(sqlcon))
            {
                sqlcnt.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        f.[id] AS [Id món ăn], 
                        f.[name] AS [Tên món ăn], 
                        c.[name] AS [Tên danh mục], 
                        f.[price] AS [Giá]
                    FROM 
                        [QuanLyQuanAn].[dbo].[Food] f
                    JOIN 
                        [QuanLyQuanAn].[dbo].[FoodCategory] c
                    ON 
                        f.[idCategory] = c.[id];", sqlcnt);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                showmonan.MonanData = dt;
                showmonan.HienThimonan();
            }
        }
    }
}
