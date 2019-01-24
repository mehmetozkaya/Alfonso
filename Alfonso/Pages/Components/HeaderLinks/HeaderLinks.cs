using Alfonso.Interfaces;
using Alfonso.Pages.Compare;
using Alfonso.ViewModels;
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
    // READ : https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-2.2
    public class HeaderLinks : ViewComponent
    {
        private readonly ICompareRazorService _compareViewModelService;
        private readonly IWishlistRazorService _wishlistRazorService;
        private string _username = null;

        public HeaderLinks(ICompareRazorService compareViewModelService, IWishlistRazorService wishlistRazorService)
        {
            _compareViewModelService = compareViewModelService ?? throw new ArgumentNullException(nameof(compareViewModelService));
            _wishlistRazorService = wishlistRazorService ?? throw new ArgumentNullException(nameof(wishlistRazorService));
        }

        public HeaderLinksViewModel HeaderLinksModel { get; set; } = new HeaderLinksViewModel();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await SetCompareModelAsync();
            return View(HeaderLinksModel);
        }        

        private async Task SetCompareModelAsync()
        {
            GetOrSetCompareCookieAndUserName();
            HeaderLinksModel.CompareViewModel = await _compareViewModelService.GetOrCreateCompareForUser(_username);
            HeaderLinksModel.WishlistViewModel = await _wishlistRazorService.GetOrCreateWishlistForUser(_username);
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
