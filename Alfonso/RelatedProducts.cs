using Alfonso.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso
{
    public class RelatedProducts : ViewComponent
    {
        private readonly ITelefonService _telefonService;

        public RelatedProducts(ITelefonService telefonService)
        {
            _telefonService = telefonService ?? throw new ArgumentNullException(nameof(telefonService));
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {            
            return View(_telefonService.GetTelefons().Take(2));
        }
    }
}
