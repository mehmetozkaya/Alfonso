using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Models
{
    public class Telefon
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public string Category { get; set; }
        public double Star { get; set; }
        public List<string> MainSpecs { get; set; }

        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public FeatureType FeatureType { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }

    public enum FeatureType
    {
        Network,
        Launch,
        Body,
        Display,
        Platform,
        Memory,
        MainCamera,
        SelfieCamera,
        Sound,
        COMMS,
        Battery
    }
}
