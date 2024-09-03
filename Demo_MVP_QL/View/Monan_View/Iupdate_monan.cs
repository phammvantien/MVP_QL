using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.View.Monan_View
{
    internal interface Iupdate_monan
    {
        int MonAnId { get; set; }
        string MonAnName { get; set; }
        float MonAnPrice { get; set; }
        int IdCategory { get; set; }
        DataGridView DataGridViewMonan { get; }
        DataTable MonanData { get; set; }
        String Message { get; set; }
        void HienThimonan();
    }
}
