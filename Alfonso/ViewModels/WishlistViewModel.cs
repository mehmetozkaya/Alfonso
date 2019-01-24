using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.ViewModels
{
    public class WishlistViewModel
    {
        public int Id { get; set; }
        public List<WishlistItemViewModel> Items { get; set; } = new List<WishlistItemViewModel>();
        public string OwnerId { get; set; }

        public string Slug
        {
            get
            {
                if (Items.Any())
                {
                    var totalSlug = string.Empty;
                    foreach (var item in Items)
                    {
                        totalSlug += item.Slug;
                        totalSlug += "vs";
                    }
                    totalSlug = $"{totalSlug}id{Id.ToString()}";
                    return totalSlug;
                }
                return string.Empty;
            }
        }
    }
}
