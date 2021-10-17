using System;
using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioVeterinario:IRepositorioVeterinario
    {

        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext=appContext;
        }
        
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado= _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado= _appContext.Veterinarios.FirstOrDefault(g => g.Id==idVeterinario);
            if(veterinarioEncontrado==null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(g => g.Id==idVeterinario);
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado= _appContext.Veterinarios.FirstOrDefault(g => g.Id==veterinario.Id);
            if (veterinarioEncontrado!=null)
            {
                veterinarioEncontrado.Nombre=veterinario.Nombre;
                veterinarioEncontrado.Apellido=veterinario.Apellido;
                veterinarioEncontrado.NumeroTelefono=veterinario.NumeroTelefono;
                veterinarioEncontrado.Direccion=veterinario.Direccion;
                veterinarioEncontrado.correo=veterinario.correo;
                veterinarioEncontrado.contrasena=veterinario.contrasena;
                veterinarioEncontrado.Latitude=veterinario.Latitude;
                veterinarioEncontrado.Longitude=veterinario.Longitude;
                veterinarioEncontrado.Registro=veterinario.Registro;
                _appContext.SaveChanges();
            }

            return veterinarioEncontrado;
        }

        Veterinario IRepositorioVeterinario.GetVeterinarioxCorreo(string correo)
        {
            Console.WriteLine("Busqueda BD por correo: "+correo);
            return _appContext.Veterinarios.FirstOrDefault(g => g.correo==correo);
        }
        Veterinario IRepositorioVeterinario.GetVeterinarioxHash(string hash)
        {
            Console.WriteLine("Busqueda BD por Hash: "+hash);
            return _appContext.Veterinarios.FirstOrDefault(g => g.contrasena==hash);
        }

    }
}