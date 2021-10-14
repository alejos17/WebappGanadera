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
                //TODO Aqui va algo antes de crear el objeto para parsear el idGanadero a int
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
            Console.WriteLine("Entrada POST");
            
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(ganado.Id>0)
            {
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                ganado = _repoGanado.UpdateGanado(ganado);
            }
            else
            {
                Console.WriteLine("Entra a guardar el nuevo ganado el ID Ganadero es: "+ganado.idGanadero);
                Listaganaderos = _repoGanadero.GetAllGanaderos();
                _repoGanado.AddGanado(ganado);
            }

            return Page();
        }

    }
}
