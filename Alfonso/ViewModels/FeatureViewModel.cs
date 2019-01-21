using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }

        public List<FeatureItemViewModel> Items { get; set; } = new List<FeatureItemViewModel>();        
    }
}
