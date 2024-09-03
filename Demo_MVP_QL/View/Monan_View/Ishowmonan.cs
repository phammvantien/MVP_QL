using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.View.Monan_View
{
    internal interface Ishowmonan
    {
        DataTable MonanData { get; set; }
        void HienThimonan();
    }
}
