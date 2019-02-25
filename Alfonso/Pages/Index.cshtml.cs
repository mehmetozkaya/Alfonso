using System;
using System.Threading.Tasks;
using Alfonso.Interfaces;
using Alfonso.Pages.Compare;
using Alfonso.ViewModels;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogRazorService _catalogService;
        private readonly ICompareRazorService _compareViewModelService;
        private readonly IWishlistRazorService _wishlistRazorService;

        private readonly ICompareService _compareService;
        private readonly IUriComposer _uriComposer;
        private string _username = null;

        public IndexModel(ICatalogRazorService catalogService, ICompareRazorService compareViewModelService, IWishlistRazorService wishlistRazorService, ICompareService compareService, IUriComposer uriComposer)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _compareViewModelService = compareViewModelService ?? throw new ArgumentNullException(nameof(compareViewModelService));
            _wishlistRazorService = wishlistRazorService ?? throw new ArgumentNullException(nameof(wishlistRazorService));
            _compareService = compareService ?? throw new ArgumentNullException(nameof(compareService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();
        public CompareViewModel CompareModel { get; set; } = new CompareViewModel();
        public WishlistViewModel WishlistModel { get; set; } = new WishlistViewModel();


        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
        {
            CatalogModel = await _catalogService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);            
        }

        public async Task<IActionResult> OnPostRemoveToCompare(int compareId, int compareItemId)
        {
            await _compareService.RemoveItemToCompare(compareId, compareItemId);
            await SetCompareModelAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCompare(CatalogItemViewModel productDetails)
        {
            if (productDetails?.Id == null)
            {
                return RedirectToPage("/Index");
            }

            await SetCompareModelAsync();
            await _compareService.AddItemToCompare(CompareModel.Id, productDetails.Id);
            await SetCompareModelAsync();
            return RedirectToPage();
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

            _username = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Constants.COMPARE_COOKIENAME, _username, cookieOptions);
        }

        public async Task<IActionResult> OnPostAddToWishlist(CatalogItemViewModel productDetails)
        {
            if (productDetails?.Id == null)
            {
                return RedirectToPage("/Index");
            }

            await SetWishlistModelAsync();
            await _wishlistRazorService.AddItemToWishlist(WishlistModel.Id, productDetails.Id);
            await SetWishlistModelAsync();
            return RedirectToPage();
        }

        private async Task SetWishlistModelAsync()
        {
            GetOrSetCompareCookieAndUserName();
            WishlistModel = await _wishlistRazorService.GetOrCreateWishlistForUser(_username);
        }
    }
}