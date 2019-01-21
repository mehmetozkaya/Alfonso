using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Interfaces;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages.Compare
{
    public class IndexModel : PageModel
    {
        private readonly ICompareRazorService _compareViewModelService;
        private readonly ICompareService _compareService;

        public IndexModel(ICompareRazorService compareViewModelService, ICompareService compareService)
        {
            _compareViewModelService = compareViewModelService ?? throw new ArgumentNullException(nameof(compareViewModelService));
            _compareService = compareService ?? throw new ArgumentNullException(nameof(compareService));
        }

        public CompareViewModel CompareModel { get; set; }

        public async Task OnGet(int compareId)
        {
            CompareModel = await _compareViewModelService.GetCompare(compareId);
        }

        public async Task<IActionResult> OnPostRemoveToCompare(int compareId, int compareItemId)
        {
            await _compareService.RemoveItemToCompare(compareId, compareItemId);          
            return RedirectToPage();
        }
    }
}