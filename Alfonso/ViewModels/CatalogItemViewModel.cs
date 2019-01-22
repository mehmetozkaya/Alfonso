using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.ViewModels
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public double Star { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }

        // TagFeatures
        public string AlfonsoPoint { get; set; }
        public string VersusPoint { get; set; }
        public string AntutuPoint { get; set; }
        public string Battery { get; set; }
        public string Camera { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }
        public string Ram { get; set; }
        public string CPU { get; set; }
    }
}
