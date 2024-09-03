using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.View.danhmuc
{
    internal interface IDeleteDanhmuc
    {
        int danhmucID { get; set; }
        string danhmucName { get; set; }

        String Message { get; set; }
        DataTable DanhmucData { get; set; }
        void HienThi();
    }
}
