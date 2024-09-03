using Demo_MVP_QL.Model;
using Demo_MVP_QL.View.TrangChu_View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.Presenter.TrangChu_Presenter
{
    public class TablePresenter
    {
        private readonly IView _view;
        private readonly Table _tableModel;
        private readonly Food _foodModel;

        public TablePresenter(IView view)
        {
            _view = view;
            _tableModel = new Table();
            _foodModel = new Food();
        }

        public void LoadDataToView()
        {
            DataTable tableData = _tableModel.GetDataFromDatabase();
            _view.DisplayTableData(tableData);

            DataTable categoryData = _foodModel.GetFoodCategories();
            _view.DisplayFoodCategories(categoryData);
        }

        public void LoadFoodsByCategory(int categoryId)
        {
            DataTable foodData = _foodModel.GetFoodsByCategory(categoryId);
            _view.DisplayFoods(foodData);
        }

        public void AddFoodToTable(int tableId, int foodId,int count)
        {
            _tableModel.AddFoodToTable(tableId, foodId,count);
            DisplayFoodItemsForTable(tableId);
        }

        public void DisplayFoodItemsForTable(int tableId)
        {
            DataTable foodItemsData = _tableModel.GetFoodItemsForTable(tableId);
            _view.DisplayFoodItemsForTable(foodItemsData);
        }
    }
}
