using System;
using System.Threading.Tasks;
using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages.Compare
{
    public class IndexModel : PageModel
    {
        private readonly ICompareRazorService _compareViewModelService;
        private readonly ICompareService _compareService;
        private readonly IFeatureRazorService _featureService;

        public IndexModel(ICompareRazorService compareViewModelService, ICompareService compareService, IFeatureRazorService featureService)
        {
            _compareViewModelService = compareViewModelService ?? throw new ArgumentNullException(nameof(compareViewModelService));
            _compareService = compareService ?? throw new ArgumentNullException(nameof(compareService));
            _featureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
        }

        public CompareViewModel CompareModel { get; set; }        
        public FeatureViewModel FeatureModel { get; set; }        

        public async Task OnGet(string slug)
        {
            var compareId = GetCompareId(slug);
            CompareModel = await _compareViewModelService.GetCompare(compareId);            
        }       

        public async Task<IActionResult> OnPostRemoveToCompare(int compareId, int compareItemId)
        {
            await _compareService.RemoveItemToCompare(compareId, compareItemId);          
            return RedirectToPage();
        }

        private static int GetCompareId(string slug)
        {
            var id = slug.Substring(slug.IndexOf("id") + 2);
            if (Int32.TryParse(id, out int compareId))
            {
                return compareId;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}