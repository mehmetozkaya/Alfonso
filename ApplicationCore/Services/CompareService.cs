using ApplicationCore.Entities.CompareAggregate;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CompareService : ICompareService
    {
        private readonly IAsyncRepository<Compare> _compareRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<CompareService> _logger;

        public Task AddItemToCompare(int compareId, int catalogItemId, decimal price, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompareAsync(int compareId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCompareItemCountAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task TransferCompareAsync(string anonymousId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
