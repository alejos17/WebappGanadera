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
    public class AtencionModel : PageModel
    {
        private static IRepositorioAtencionEjemplar _repoAtencionEjemplar = new RepositorioAtencionEjemplar(new Persistencia.AppContext());

        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());

        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        [BindProperty]
        public AtencionEjemplar atencion { get; set; }

        public IEnumerable<Ejemplar> Listaejemplares { get; private set; }

        public IEnumerable<Veterinario> Listaveterinarios { get; private set; }

        public int atencionId { get; set; }
        public string Mensaje { get; set; }
        public string Mensaje2 { get; set; }

        public IActionResult OnGet(int? atencionId)
        {
            if(atencionId.HasValue)
            {
                atencion = _repoAtencionEjemplar.GetAtencion(atencionId.Value);
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                Listaveterinarios = _repoVeterinario.GetAllVeterinarios();
            }
            else
            {
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                Listaveterinarios = _repoVeterinario.GetAllVeterinarios();
                atencion = new AtencionEjemplar();
            }

            if(atencion == null)
            {
                return RedirectToPage("./Error");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                return Page();
            }
            if(atencion.Id>0)
            {
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                Listaveterinarios = _repoVeterinario.GetAllVeterinarios();
            }
            else
            {
                Listaejemplares = _repoEjemplar.GetAllEjemplar();
                Listaveterinarios = _repoVeterinario.GetAllVeterinarios();
            }

            return Page();
        }

        public void OnPostAdd(AtencionEjemplar atencionUp)
        {
            Console.WriteLine("Veterinario: "+atencionUp.idVeterinario);
            if(atencionUp != null)
            {
                if(atencionUp.Id>0)
                {
                    _repoAtencionEjemplar.UpdateAtencion(atencionUp);
                    Mensaje = "*** La novedad en la historia médica ha sido modificada ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
                else
                {
                    _repoAtencionEjemplar.AddAtencion(atencionUp);
                    Mensaje = "*** Se agrego la novedad al historial médico del Animal ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
            }
            Listaejemplares = _repoEjemplar.GetAllEjemplar();
            Listaveterinarios = _repoVeterinario.GetAllVeterinarios();
        }

    }
}
