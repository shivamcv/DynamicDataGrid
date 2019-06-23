using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataGrid.Model
{
    public class ColumnInfo
    {
        public int Index { get; set; }
        public string BindingProperty { get; set; }
        public string Template { get; set; }
        public string Header { get; set; }

        public ColumnInfo(int index, string bindingProperty, string template, string header)
        {
            Index = index;
            BindingProperty = bindingProperty;
            Template = template;
            Header = header;
        }
    }
}