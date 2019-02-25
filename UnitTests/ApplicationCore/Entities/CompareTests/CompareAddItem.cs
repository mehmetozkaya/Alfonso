using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Xunit;
using ApplicationCore.Entities.CompareAggregate;

namespace UnitTests.ApplicationCore.Entities.CompareTests
{
    public class CompareAddItem
    {
        private int _testCatalogItemId = 123;
        private decimal _testUnitPrice = 1.23m;
        private int _testQuantity = 2;

        [Fact]
        public void AddsCompareItemIfNotPresent()
        {
            var compare = new Compare();
            compare.AddItem(_testCatalogItemId);

            var firstItem = compare.Items.Single();
            Assert.Equal(_testCatalogItemId, firstItem.CatalogItemId);
        }



    }
}
