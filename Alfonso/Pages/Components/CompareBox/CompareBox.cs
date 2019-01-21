using Alfonso.Interfaces;
using Alfonso.Pages.Compare;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Pages.Components.Compare
{
    public class CompareBox : ViewComponent
    {
        private readonly ICompareRazorService _compareService;

        public CompareBox(ICompareRazorService compareService)
        {
            _compareService = compareService ?? throw new ArgumentNullException(nameof(compareService));
        }        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new CompareViewModel();
            vm = await GetCompareViewModelAsync();
            return View(vm);
        }

        private async Task<CompareViewModel> GetCompareViewModelAsync()
        {
            string anonymousId = GetCompareIdFromCookie();
            if (anonymousId == null) return new CompareViewModel();
            return await _compareService.GetOrCreateCompareForUser(anonymousId);
        }

        private string GetCompareIdFromCookie()
        {
            if (Request.Cookies.ContainsKey(Constants.COMPARE_COOKIENAME))
            {
                return Request.Cookies[Constants.COMPARE_COOKIENAME];
            }
            return null;
        }       
    }
}
