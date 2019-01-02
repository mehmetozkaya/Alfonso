using Alfonso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfonso.Services
{
    public interface ITelefonService
    {
        List<Telefon> GetTelefons();
    }
}
