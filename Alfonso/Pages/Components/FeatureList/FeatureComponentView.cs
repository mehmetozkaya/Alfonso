using Alfonso.ViewModels;
using System.Collections.Generic;

namespace Alfonso.Pages.Components.FeatureList
{
    public class FeatureComponentView
    {
        public IEnumerable<FeatureViewModel> FeatureViewModel { get; set; }
        public bool IsCompareMode { get; set; }
    }
}
