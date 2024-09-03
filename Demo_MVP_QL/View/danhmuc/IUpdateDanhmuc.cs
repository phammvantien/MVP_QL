using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.View.danhmuc
{
    internal interface IUpdateDanhmuc
    {
        int danhmucID { get; set; }
        string danhmucName { get; set; }
        DataGridView DataGridViewDanhmuc { get; }
        String Message { get; set; }
        DataTable DanhmucData { get; set; }
        void HienThi();


    }
}
