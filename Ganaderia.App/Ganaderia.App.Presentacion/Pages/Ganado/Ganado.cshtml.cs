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
        public IEnumerable<Ganadero> Listaganaderos { get; private set; }

        public int ganadoId { get; set; }

        public IActionResult OnGet(int? ganadoId)
        {
            if(ganadoId.HasValue)
            {
                ganado = _repoGanado.GetGanado(ganadoId.Value);
                Listaganaderos = _repoGanadero.GetAllGanaderos();
            }
            else
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
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
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                //ganado = _repoGanado.UpdateGanado(ganado);
            }
            else
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                //_repoGanado.AddGanado(ganado);
            }

            return Page();
        }

        public void OnPostAdd(Ganado ganadoUp)
        {
            Console.WriteLine("Ganado Raza: "+ganadoUp.raza);
            if(ganadoUp != null)
            {
                if(ganadoUp.Id>0)
                {
                    _repoGanado.UpdateGanado(ganadoUp);
                }
                else
                {
                    _repoGanado.AddGanado(ganadoUp);
                }
            }
            Listaganaderos = _repoGanadero.GetAllGanaderos();

        }

    }
}
