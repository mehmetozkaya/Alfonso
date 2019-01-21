using Alfonso.Pages.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Interfaces
{
    public interface ICompareRazorService
    {
        Task<CompareViewModel> GetOrCreateCompareForUser(string userName);
        Task<CompareViewModel> GetCompare(int compareId);        
    }
}
