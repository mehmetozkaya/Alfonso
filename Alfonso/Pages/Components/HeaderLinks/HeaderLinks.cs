using Alfonso.Interfaces;
using Alfonso.Pages.Compare;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Pages.Components.HeaderLinks
{
    // TODO : Burada 2. kez compare e sorgu atılıyor, UI bozdugu icin CompareBox in icine alınamadı - burada cookie den oku!
    public class HeaderLinks : ViewComponent
    {
        private readonly ICompareRazorService _compareViewModelService;
        private string _username = null;

        public HeaderLinks(ICompareRazorService compareViewModelService)
        {
            _compareViewModelService = compareViewModelService ?? throw new ArgumentNullException(nameof(compareViewModelService));
        }

        public CompareViewModel CompareModel { get; set; } = new CompareViewModel();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await SetCompareModelAsync();
            return View(CompareModel);
        }        

        private async Task SetCompareModelAsync()
        {
            GetOrSetCompareCookieAndUserName();
            CompareModel = await _compareViewModelService.GetOrCreateCompareForUser(_username);
        }

        private void GetOrSetCompareCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Constants.COMPARE_COOKIENAME))
            {
                _username = Request.Cookies[Constants.COMPARE_COOKIENAME];
            }
            if (_username != null) return;           
        }

    }
}
