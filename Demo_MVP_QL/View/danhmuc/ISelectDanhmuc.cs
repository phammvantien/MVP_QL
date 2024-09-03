using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.View.danhmuc
{
    public  interface ISelectDanhmuc
    {
        int SelectedRowIndex { get; }
        string DanhmucId { get; set; }
        string DanhmucName { get; set; }
        DataGridView DataGridViewDanhmuc { get; }
      
    }
}
