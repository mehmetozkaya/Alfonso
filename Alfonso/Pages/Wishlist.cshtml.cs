using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Interfaces;
using Alfonso.ViewModels;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages
{
    public class WishlistModel : PageModel
    {
        private readonly IWishlistRazorService _wishlistService;
        private readonly IUriComposer _uriComposer;

        public WishlistModel(IWishlistRazorService wishlistService, IUriComposer uriComposer)
        {
            _wishlistService = wishlistService ?? throw new ArgumentNullException(nameof(wishlistService));
            _uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        public async Task OnGet(string slug)
        {
            var wishlistId = GetWishlistId(slug);
            WishlistViewModel = await _wishlistService.GetWishlist(wishlistId);
        }

        public async Task<IActionResult> OnPostRemoveToWishlist(int WishlistId, int WishlistItemId)
        {
            await _wishlistService.RemoveItemToWishlist(WishlistId, WishlistItemId);
            return RedirectToPage();
        }

        private static int GetWishlistId(string slug)
        {
            var id = slug.Substring(slug.IndexOf("id") + 2);
            if (Int32.TryParse(id, out int wishlistId))
            {
                return wishlistId;
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}