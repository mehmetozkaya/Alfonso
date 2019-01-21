using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.FeatureAggregate
{
    public class FeatureItem : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
