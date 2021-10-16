
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

        public string Mensaje { get; set; }
        public string Mensaje2 { get; set; }
        
        
        //Para Consultar  el signo ? pregunta si viene Id o no para modificar o crear
        public IActionResult OnGet(int? ganaderoId)
        {
            if(ganaderoId.HasValue)
            {
                ganadero = _repoGanadero.GetGanadero(ganaderoId.Value);
            }
            else
            {    
                ganadero = new Ganadero();
            }
            
            if(ganadero==null)
            {
            return RedirectToPage("./Error");
            }else
            {
            return Page();
            }
        }

        //Para editar valores de Ganadero
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid) //Verifica que los campos de texto cumplan con Requerimientos de Entidad en Dominio
            {
                return Page();
            }
            if(ganadero.Id>0)  //Si el ID es mayor a 0 es porque ya existe y lo va a actualizar solamente....  si no es nuevo y lo agrega
            {
                ganadero = _repoGanadero.UpdateGanadero(ganadero);
                Mensaje = "*** El Ganadero ha sido actualizado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            else
            {
                Console.WriteLine("ID Ga: "+ganadero.Id);
                Console.WriteLine("Nombre: "+ganadero.Nombre);
                _repoGanadero.AddGanadero(ganadero);
                Mensaje = "*** El Ganadero ha sido creado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            
            return Page();
        }

        public void OnPostAdd(Ganadero ganaderoUp)
        {
            Console.WriteLine("Ganadero ID: "+ganaderoUp.Id);
            if(ganaderoUp != null)
            {
                if(ganaderoUp.Id>0)
                {
                    _repoGanadero.UpdateGanadero(ganaderoUp);
                    Mensaje = "*** El Ganadero ha sido actualizado exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
                else
                {
                    _repoGanadero.AddGanadero(ganaderoUp);
                    Mensaje = "*** El Ganadero ha sido creado exitosamente ***";
                    Mensaje2 = "-- Haga click en Atrás para continuar --";
                }
            }

        }

    }
}
