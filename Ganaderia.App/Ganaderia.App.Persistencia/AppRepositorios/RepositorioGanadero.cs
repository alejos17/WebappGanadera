using System;
using System.Collections.Generic;
using System.Linq;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioGanadero:IRepositorioGanadero
    {

        private readonly AppContext _appContext;

        public RepositorioGanadero(AppContext appContext)
        {
            _appContext=appContext;
        }
        Ganadero IRepositorioGanadero.AddGanadero(Ganadero ganadero)
        {
            var ganaderoAdicionado= _appContext.Ganaderos.Add(ganadero);
            _appContext.SaveChanges();
            return ganaderoAdicionado.Entity;
        }

        void IRepositorioGanadero.DeleteGanadero(int idGanadero)
        {
            var ganaderoEncontrado= _appContext.Ganaderos.FirstOrDefault(g => g.Id==idGanadero);
            if(ganaderoEncontrado==null)
                return;
            _appContext.Ganaderos.Remove(ganaderoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Ganadero> IRepositorioGanadero.GetAllGanaderos()
        {
            return _appContext.Ganaderos;
        }

        Ganadero IRepositorioGanadero.GetGanadero(int idGanadero)
        {
            return _appContext.Ganaderos.FirstOrDefault(g => g.Id==idGanadero);
        }
        
        Ganadero IRepositorioGanadero.UpdateGanadero(Ganadero ganadero)
        {
            var ganaderoEncontrado= _appContext.Ganaderos.FirstOrDefault(g => g.Id==ganadero.Id);
            if (ganaderoEncontrado!=null)
            {
                ganaderoEncontrado.Nombre=ganadero.Nombre;
                ganaderoEncontrado.Apellido=ganadero.Apellido;
                ganaderoEncontrado.NumeroTelefono=ganadero.NumeroTelefono;
                ganaderoEncontrado.Direccion=ganadero.Direccion;
                ganaderoEncontrado.correo=ganadero.correo;
                ganaderoEncontrado.contrasena=ganadero.contrasena;
                ganaderoEncontrado.Latitude=ganadero.Latitude;
                ganaderoEncontrado.Longitude=ganadero.Longitude;

                _appContext.SaveChanges();
            }

            return ganaderoEncontrado;
        }

        Ganadero IRepositorioGanadero.GetGanaderoxCorreo(string correo)
        {
            Console.WriteLine("Busqueda BD por correo: "+correo);
            return _appContext.Ganaderos.FirstOrDefault(g => g.correo==correo);
        }
        Ganadero IRepositorioGanadero.GetGanaderoxHash(string hash)
        {
            Console.WriteLine("Busqueda BD por Hash: "+hash);
            return _appContext.Ganaderos.FirstOrDefault(g => g.contrasena==hash);
        }
    }
}