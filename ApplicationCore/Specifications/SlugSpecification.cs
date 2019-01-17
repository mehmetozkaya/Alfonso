using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class SlugSpecification : BaseSpecification<CatalogItem>
    {
        public SlugSpecification(string slug)
            : base(c => c.Slug == slug)
        {
        }        
    }
}
