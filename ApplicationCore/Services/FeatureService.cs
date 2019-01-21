using ApplicationCore.Entities.FeatureAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IAsyncRepository<Feature> _featureRepository;
        private readonly IAsyncRepository<FeatureItem> _featureItemRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<FeatureService> _logger;

        public FeatureService(IAsyncRepository<Feature> featureRepository, IAsyncRepository<FeatureItem> featureItemRepository, IUriComposer uriComposer, IAppLogger<FeatureService> logger)
        {
            _featureRepository = featureRepository ?? throw new ArgumentNullException(nameof(featureRepository));
            _featureItemRepository = featureItemRepository ?? throw new ArgumentNullException(nameof(featureItemRepository));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IReadOnlyList<Feature>> GetFeatures(int catalogItemId)
        {
            var featureSpec = new FeatureWithItemsSpecification(catalogItemId);
            var featureList = await _featureRepository.ListAsync(featureSpec);

            return featureList;
        }

    }
}
