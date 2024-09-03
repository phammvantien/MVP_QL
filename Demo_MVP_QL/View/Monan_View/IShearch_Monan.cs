using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVP_QL.View.Monan_View
{
    internal interface IShearch_Monan
    {

        string MonAnName { get; set; }
        string Message { get; set; }
        DataTable MonAnData { get; set; }  // Add this property to hold search results
        void HienThiMonan();
    }
}
