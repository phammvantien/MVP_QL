using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.View.Monan_View
{
    internal interface Iselect_Monan
    {
        int SelectedRowIndexmonan { get; }
        int MonAnId { get; set; }
        string MonAnName { get; set; }
        float MonAnPrice { get; set; }
        int IdCategory { get; set; }

        DataGridView DataGridViewMonan { get; }
    }
}
