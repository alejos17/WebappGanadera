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
    public class RegisterModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        public Veterinario veterinario { get; set; }
        public Ganadero ganadero { get; set; }
        public string Mensaje { get; set; }

        public string Tipo { get; set; }

        private static IMd5 _Md5= new Md5();
        public void OnGet()
        {
            ganadero = new Ganadero();
            veterinario = new Veterinario();
        }

        public void OnPostAddG(Ganadero ganaderoUp)
        {
            if(ganaderoUp != null)
            {
                Console.WriteLine("Ganadero ID: "+ganaderoUp.Id);
                Console.WriteLine("Password Simple: "+ganaderoUp.contrasena);
                ganaderoUp.contrasena = _Md5.ObtenerMD5(ganaderoUp.contrasena);
                Console.WriteLine("Password Hash: "+ganaderoUp.contrasena);
                _repoGanadero.AddGanadero(ganaderoUp);
                Mensaje = "*** El Ganadero ha sido creado exitosamente ***";
            }
            else
            {
                Mensaje = "Ganadero no creado ERROR";
            }

        }

        public void OnPostAddV(Veterinario veterinarioUp)
        {
            if(veterinarioUp != null)
            {
                Console.WriteLine("Veterinario ID: "+veterinarioUp.Id);
                Console.WriteLine("Password Simple: "+veterinarioUp.contrasena);
                veterinarioUp.contrasena = _Md5.ObtenerMD5(veterinarioUp.contrasena);
                Console.WriteLine("Password Hash: "+veterinarioUp.contrasena);
                _repoVeterinario.AddVeterinario(veterinarioUp);
                Mensaje = "*** El Veterinario ha sido creado exitosamente ***";
            }
            else
            {
                Mensaje = "Veterinario no creado ERROR";
            }

        }

        public void OnPostLista(string tipo)
        {
            Tipo = tipo;
        }
    }
}
