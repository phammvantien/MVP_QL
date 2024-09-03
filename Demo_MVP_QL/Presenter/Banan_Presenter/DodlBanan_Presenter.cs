using Demo_MVP_QL.View.Banan_View;
using System;

namespace Demo_MVP_QL.Presenter.Banan_Presenter
{
    internal class DodlBanan_Presenter
    {
        private readonly IDodulieuBanan _view;

        public DodlBanan_Presenter(IDodulieuBanan view)
        {
            _view = view;
        }

        public void HienThiChiTietBanan()
        {
            int i = _view.SelectedRowIndexBanan;
            if (i >= 0)
            {
                _view.BananId = Convert.ToInt32(_view.DataGridViewBanan.Rows[i].Cells["Mã"].Value);
                _view.BananName = _view.DataGridViewBanan.Rows[i].Cells["Tên"].Value.ToString();
                _view.BananStatus = _view.DataGridViewBanan.Rows[i].Cells["Trạng Thái"].Value.ToString() == "Có người";
            }
        }
    }
}
