using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfmvvm_02.Models.LoadCSV
{
    public class LoadCSVItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public string Purchase { get; set; }

        public int Quanity { get; set; }
        public decimal UnitPrice { get; set; }
   
        public decimal ToalCost { get; set; }

        public string Location { get; set; }
        public int LocationLevel { get; set; }

        public int Priority { get; set; }

        public int DaysTillDelivery { get; set;}





    }
}
