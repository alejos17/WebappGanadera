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
        [BindProperty]  //Enlazar el modelo con el input del HTML
        public Ganadero ganadero { get; set; }

        public int ganaderoId { get; set; }
        
        
        
        public IActionResult OnGet(int ganaderoId)
        {
            if(ganaderoId==0987654321)
            {
                return Page();
            }
            else{
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

        //Para editar valores de Ganadero
        public IActionResult OnPost()
        {
            ganadero = _repoGanadero.UpdateGanadero(ganadero);
            return Page();
        }

    }
}
