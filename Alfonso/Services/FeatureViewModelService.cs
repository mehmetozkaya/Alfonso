using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class FeatureViewModelService : IFeatureViewModelService
    {
        private readonly IFeatureService _featureService;
        private readonly IUriComposer _uriComposer;

        public FeatureViewModelService(IFeatureService featureService, IUriComposer uriComposer)
        {
            _featureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public Task<FeatureViewModel> GetFeatures(int catalogItemId)
        {
            throw new NotImplementedException();
        }
    }
}
