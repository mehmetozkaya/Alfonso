using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Pages.Compare
{
    public class CompareViewModel
    {
        public int Id { get; set; }
        public List<CompareItemViewModel> Items { get; set; } = new List<CompareItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
    }
}
