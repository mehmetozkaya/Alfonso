using ApplicationCore.Entities.CompareAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class CompareWithItemsSpecification : BaseSpecification<Compare>
    {
        public CompareWithItemsSpecification(int compareId)
           : base(b => b.Id == compareId)
        {
            AddInclude(b => b.Items);
        }
    }
}
