using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICompareService
    {
        Task<int> GetCompareItemCountAsync(string userName);
        Task TransferCompareAsync(string anonymousId, string userName);
        Task AddItemToCompare(int compareId, int catalogItemId);
        Task RemoveItemToCompare(int compareId, int compareItemId);        
        Task DeleteCompareAsync(int compareId);
    }
}
