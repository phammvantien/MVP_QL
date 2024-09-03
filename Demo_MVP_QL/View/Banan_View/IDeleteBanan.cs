using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_MVP_QL.View.Banan_View
{
    internal interface IDeleteBanan
    {
        int BananId { get; set; }
        string BananName { get; set; }
        Boolean BananStatus { get; set; }
        DataGridView DataGridViewBanan { get; set; }
        String Message { get; set; }
    }
}
