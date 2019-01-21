using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public class FeatureRazorService : IFeatureRazorService
    {
        private readonly IFeatureService _featureService;
        private readonly IUriComposer _uriComposer;

        public FeatureRazorService(IFeatureService featureService, IUriComposer uriComposer)
        {
            _featureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public async Task<IEnumerable<FeatureViewModel>> GetFeatures(int catalogItemId)
        {
            var featureList = await _featureService.GetFeatures(catalogItemId);

            var featureViewModelList = new List<FeatureViewModel>();
            
            foreach (var feature in featureList)
            {
                var featureViewModel = new FeatureViewModel
                {
                    Id = feature.Id,
                    Name = feature.Name,
                    SubName = feature.SubName
                };

                foreach (var item in feature.Items)
                {
                    var featureViewModelItem = new FeatureItemViewModel
                    {
                        FeatureId = feature.Id,
                        Name = item.Name,
                        Value = item.Value
                    };

                    featureViewModel.Items.Add(featureViewModelItem);
                }

                featureViewModelList.Add(featureViewModel);
            }

            return featureViewModelList;
        }
    }
}
