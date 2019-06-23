using DynamicDataGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new StockViewModel();
            this.DataContext = vm;
            StockGrid.ItemsSource = vm.StockData;
            foreach (var col in vm.Columns.OrderBy(p => p.Index))
            {
                var templateColumn = new DataGridTemplateColumn();
                templateColumn.Header = col.Header;
                string xaml = @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""><ContentControl Content=""{0}"" ContentTemplate=""{1}"" /></DataTemplate>";
                xaml = string.Format(xaml, "{Binding " + col.BindingProperty + "}", "{StaticResource " + col.Template + "}");
                byte[] byteArray = Encoding.ASCII.GetBytes(xaml);
                MemoryStream stream = new MemoryStream(byteArray);
                var template = (DataTemplate)XamlReader.Load(stream);

                templateColumn.CellTemplate = template;
                StockGrid.Columns.Add(templateColumn);
            }
        }
    }
}