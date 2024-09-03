using Demo_MVP_QL.View.Monan_View;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Demo_MVP_QL.Presenter.MonAn_Presenter
{
    internal class SearchMonan_Presenter
    {
        private readonly IShearch_Monan view;
        private readonly string sqlcon = @"Data Source=DESKTOP-E4S6SRL\SQLEXPRESS;Initial Catalog=QuanLyQuanAn;Integrated Security=True;";

        public SearchMonan_Presenter(IShearch_Monan view)
        {
            this.view = view;
        }
        public void Timkiemmonan(string searchName)
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
                f.[idCategory] = c.[id]
            WHERE 
                f.[name] LIKE @searchName;", sqlcnt);

                cmd.Parameters.AddWithValue("@searchName", "%" + searchName + "%");

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                view.MonAnData = dt;
                view.HienThiMonan();
            }
        }



    }

}
