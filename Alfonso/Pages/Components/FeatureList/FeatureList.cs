using Alfonso.Interfaces;
using Alfonso.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Pages.Components.FeatureList
{
    public class FeatureList : ViewComponent
    {
        private readonly IFeatureRazorService _featureService;

        public FeatureList(IFeatureRazorService featureService)
        {
            _featureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
        }

        public int RowCount { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(int catalogItemId)
        {            
            var vm = await _featureService.GetFeatures(catalogItemId);
            int count = vm.Count();
            RowCount = int.Parse(Math.Ceiling(((decimal)count / 2)).ToString());

            return View(vm);
        }
    }
}
