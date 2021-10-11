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

        public Ganadero ganadero { get; set; }
        
        
        
        public IActionResult OnGet(int ganaderoId)
        {
            ganadero = _repoGanadero.GetGanadero(ganaderoId);
            if(ganadero==null)
            {
                return RedirectToPage("./Error");
            }else
            {
                return Page();
            }
        }
    }
}
