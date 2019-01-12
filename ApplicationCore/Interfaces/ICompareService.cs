﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICompareService
    {
        Task<int> GetCompareItemCountAsync(string userName);
        Task TransferCompareAsync(string anonymousId, string userName);
        Task AddItemToCompare(int compareId, int catalogItemId, decimal price, int quantity);
        //Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task DeleteCompareAsync(int compareId);
    }
}