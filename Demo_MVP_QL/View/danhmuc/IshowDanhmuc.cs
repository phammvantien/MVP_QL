using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.View.danhmuc
{
     public interface IshowDanhmuc
    {
        DataTable DanhmucData { get; set; }
        void HienThi();

        
    }
}
