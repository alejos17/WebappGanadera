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
    public class GanadoModel : PageModel
    {
        private static IRepositorioGanado _repoGanado= new RepositorioGanado(new Persistencia.AppContext());
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());
        [BindProperty]
        public Ganado ganado { get; set; }
        public Ganadero ganadero { get; set; }

        public int ganadoId { get; set; }

        public IActionResult OnGet(int? ganadoId)
        {
            if(ganadoId.HasValue)
            {
                ganado = _repoGanado.GetGanado(ganadoId.Value);
                ganadero = _repoGanadero.GetGanadero(ganado.idGanadero);
            }
            else
            {
                ganado = new Ganado();
            }

            if(ganado==null)
            {
                return RedirectToPage("./Error");
            }
            else
            {
                return Page();
            }
        }

        //Para editar valores de Ganado
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(ganado.Id>0)
            {
                ganado = _repoGanado.UpdateGanado(ganado);
            }
            else
            {
                _repoGanado.AddGanado(ganado);
            }

            return Page();
        }

    }
}
