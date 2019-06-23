using DynamicDataGrid.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataGrid.ViewModel
{
    public class StockViewModel
    {
        public List<Stock> StockData { get; set; }
        public List<ColumnInfo> Columns { get; set; }

        public StockViewModel()
        {
            var data = File.ReadAllLines("HistoricalPrices.csv");
            StockData = data.Skip(1).Select(p => new Stock()
            {
                Date = DateTime.ParseExact(p.Split(',')[0], "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture),
                Open = double.Parse(p.Split(',')[1]),
                High = double.Parse(p.Split(',')[2]),
                Close = double.Parse(p.Split(',')[3]),
                Low = double.Parse(p.Split(',')[4]),
            }).ToList();

            data = File.ReadAllLines("ColumnInfo.csv");
            Columns = data.Skip(1).Select(p => new ColumnInfo(int.Parse(p.Split(',')[0]), p.Split(',')[1], p.Split(',')[2], p.Split(',')[3])).ToList();
        }
    }
}