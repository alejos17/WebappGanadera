using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Presentacion.Pages
{
    public class IndexModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        private static IMd5 _Md5= new Md5();
        public Ganadero ganaderoxcorreo { get; set; }
        public Ganadero ganaderoxhash { get; set; }
        public Veterinario veterinarioxcorreo { get; set; }
        public Veterinario veterinarioxhash { get; set; }
        public string Mensaje { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string usuario, string contrasena)
        {
            Console.WriteLine("Usuario: "+usuario);
            Console.WriteLine("Contraseña: "+contrasena);
            contrasena = _Md5.ObtenerMD5(contrasena);
            Console.WriteLine("Hash: "+contrasena);
            if (usuario != null && contrasena != null)
            {
                ganaderoxcorreo = _repoGanadero.GetGanaderoxCorreo(usuario);
                veterinarioxcorreo = _repoVeterinario.GetVeterinarioxCorreo(usuario);
                
                if(ganaderoxcorreo!=null || veterinarioxcorreo!=null)
                {
                    ganaderoxhash =_repoGanadero.GetGanaderoxHash(contrasena);
                    veterinarioxhash = _repoVeterinario.GetVeterinarioxHash(contrasena);

                    if(ganaderoxhash!=null || veterinarioxhash!= null)
                    {
                        Console.WriteLine("Usuario y Clave Correcto");
                        return RedirectToPage("./Inicio/Menu");
                    }
                    else
                    {
                        Console.WriteLine("Clave Hash no encontrada");
                        Mensaje = "Clave Incorrecta";
                    }
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                    Mensaje = "Usuario no existe";
                }
            }
            else
            {
                Mensaje = "No hay datos";
            }
            return Page();
        }
    }
}
