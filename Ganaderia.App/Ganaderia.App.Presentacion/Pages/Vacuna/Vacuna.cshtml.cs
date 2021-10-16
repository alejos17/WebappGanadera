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
    public class VacunaModel : PageModel
    {
        private static IRepositorioVacuna _repoVacuna= new RepositorioVacuna(new Persistencia.AppContext());
        [BindProperty]  //Enlazar el modelo con el input del HTML
        public Vacuna vacuna { get; set; }

        public int vacunaId { get; set; }

        public string Mensaje { get; set; }
        public string Mensaje2 { get; set; }
        
        
        //Para Consultar  el signo ? pregunta si viene Id o no para modificar o crear
        public IActionResult OnGet(int? vacunaId)
        {
            if(vacunaId.HasValue)
            {
                vacuna = _repoVacuna.GetVacuna(vacunaId.Value);
            }
            else
            {    
                vacuna = new Vacuna();
            }
            
            if(vacuna==null)
            {
            return RedirectToPage("./Error");
            }else
            {
            return Page();
            }
        }

        //Para editar valores de Vacuna
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid) //Verifica que los campos de texto cumplan con Requerimientos de Entidad en Dominio
            {
                return Page();
            }
            if(vacuna.Id>0)  //Si el ID es mayor a 0 es porque ya existe y lo va a actualizar solamente....  si no es nuevo y lo agrega
            {
                vacuna = _repoVacuna.UpdateVacuna(vacuna);
                Mensaje = "*** El Vacuna ha sido actualizado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            else
            {
                _repoVacuna.AddVacuna(vacuna);
                Mensaje = "*** El Vacuna ha sido creado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            
            return Page();
        }


        public void OnPostAdd(Vacuna vacunaUp)
        {
            Console.WriteLine("Vacuna ID: "+vacunaUp.Id);
            if(vacunaUp != null)
            {
                if(vacunaUp.Id>0)
                {
                    _repoVacuna.UpdateVacuna(vacunaUp);
                    Mensaje = "*** La Vacuna ha sido actualizado exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
                else
                {
                    _repoVacuna.AddVacuna(vacunaUp);
                    Mensaje = "*** La Vacuna ha sido creado exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
            }
    }

    }
}
