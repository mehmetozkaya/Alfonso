using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.ViewModels
{
    public class FeatureItemViewModel
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
