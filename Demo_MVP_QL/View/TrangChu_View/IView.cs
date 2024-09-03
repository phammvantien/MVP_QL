using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.View.TrangChu_View
{
    public interface IView
    {
        void DisplayTableData(DataTable dataTable);
        void DisplayFoodCategories(DataTable dataTable);
        void DisplayFoods(DataTable dataTable);
        void DisplayFoodItemsForTable(DataTable dataTable);
    }
}
