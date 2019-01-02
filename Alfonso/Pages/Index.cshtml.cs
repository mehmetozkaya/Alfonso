using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alfonso.Models;
using Alfonso.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfonso.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITelefonService _telefonService;

        public IndexModel(ITelefonService telefonService)
        {
            _telefonService = telefonService ?? throw new ArgumentNullException(nameof(telefonService));
        }

        public List<Telefon> TelefonList { get; set; }

        public void OnGet()
        {
            TelefonList = _telefonService.GetTelefons();
        }
    }
}