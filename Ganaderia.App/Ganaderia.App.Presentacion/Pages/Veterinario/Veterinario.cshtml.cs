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
    public class VeterinarioModel : PageModel
    {
        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        [BindProperty]  //Enlazar el modelo con el input del HTML
        public Veterinario veterinario { get; set; }

        public int veterinarioId {get; set; }

        public string Mensaje {get; set; }
        public string Mensaje2 {get; set; }

        //Para Consultar  el signo ? pregunta si viene Id o no para modificar o crear
        public IActionResult OnGet(int? veterinarioId)
        {
            if(veterinarioId.HasValue)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId.Value);
            }
            else
            {    
                veterinario = new Veterinario();
            }
            
            if(veterinario==null)
            {
            return RedirectToPage("./Error");
            }else
            {
            return Page();
            }
        }

        //Para editar valores de Veterinario
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid) //Verifica que los campos de texto cumplan con Requerimientos de Entidad en Dominio
            {
                return Page();
            }
            if(veterinarioId>0)  //Si el ID es mayor a 0 es porque ya existe y lo va a actualizar solamente....  si no es nuevo y lo agrega
            {
                veterinario = _repoVeterinario.UpdateVeterinario(veterinario);
                Mensaje = "*** El veterinario ha sido actualizado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            else
            {
                _repoVeterinario.AddVeterinario(veterinario);
                Mensaje = "*** El Veterinario ha sido creado exitosamente ***";
                Mensaje2 = "-- Haga click en Atrás para continuar --";
            }
            
            return Page();
        }

    }
}
