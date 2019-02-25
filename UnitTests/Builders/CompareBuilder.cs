using ApplicationCore.Entities.CompareAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Builders
{
    public class CompareBuilder
    {
        private Compare _compare;
        public int CompareId => 1;

        public CompareBuilder()
        {
            _compare = WithNoItems();
        }

        private Compare WithNoItems()
        {
            _compare = new Compare { Id = CompareId };
            return _compare;
        }

        private Compare WithOneCompareItem()
        {
            _compare = new Compare { Id = CompareId };
            _compare.AddItem(2);
            return _compare;
        }
    }
}
