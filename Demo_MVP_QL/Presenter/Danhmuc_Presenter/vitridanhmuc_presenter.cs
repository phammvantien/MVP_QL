using Demo_MVP_QL.View.danhmuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.Presenter.Danhmuc_Presenter
{
    public class vitridanhmuc_presenter
    {
        ISelectDanhmuc selectDanhmucView;

        public vitridanhmuc_presenter(ISelectDanhmuc selectDanhmucView)
        {
            this.selectDanhmucView = selectDanhmucView;
        }

        public void HienThiChiTietDanhmuc()
        {
            int i = selectDanhmucView.SelectedRowIndex;
            if (i >= 0)
            {
                selectDanhmucView.DanhmucId = selectDanhmucView.DataGridViewDanhmuc.Rows[i].Cells[0].Value.ToString();
                selectDanhmucView.DanhmucName = selectDanhmucView.DataGridViewDanhmuc.Rows[i].Cells[1].Value.ToString();
            }
        }
    }
}
