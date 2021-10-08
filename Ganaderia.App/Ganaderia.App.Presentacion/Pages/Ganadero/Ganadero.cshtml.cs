using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Presentacion.Pages
{
    public class GanaderoModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());

        public IEnumerable<Ganadero> ganaderos { get; private set; }
        
        
        public void OnGet()
        {
            ganaderos = _repoGanadero.GetAllGanaderos();
        }
    }
}
