using System.Collections.Generic;
using System;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Consola
{
    class Program
    {
        //Llamo una instancia de los Repositorios para los metodos CRUD
        //Ganaderos
        private static IRepositorioGanadero _repoGanadero= new RepositorioGanadero(new Persistencia.AppContext());
        //Veterinario
        private static IRepositorioVeterinario _repoVeterinario= new RepositorioVeterinario(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola, GanaderiaWebApp!");
            
            //Primer prueba, crear Ganadero
            //AddGanadero();   //Se llama el metodo de esta clase creado mas abajo
            //Console.WriteLine("Hola, Creando Ganadero!");
            //Console.WriteLine("Ganadero Guardado en BD!");

            //AddVeterinario();
            //Console.WriteLine("Creando Veterinario!");
            //Console.WriteLine("Veterinario Creado con exito!");
            
            //Segunda Prueba, Buscar Ganadero se comenta anterior para no repetir Add
            //Console.WriteLine("Buscando Ganadero!");
            //BuscarGanadero(1);
            //Console.WriteLine("Ganadero Encontrado");

            //Tercera Prueba, Lista de TODO
            GetAll();
        }

        //Metodo PRUEBA para crear un ganadero en la Base de Datos
        private static void AddGanadero()
        {
            var ganadero = new Ganadero
            {
                //Id = 34235897,  //Crear atributo para documento de ID
                Nombre = "Carlos",
                Apellido = "Gonzalez",
                NumeroTelefono = "3145634567",
                Direccion = "Calle 24 No 78-23",
                correo = "cgonzalez@gmail.com",
                contrasena = "123456",
                Latitude = 5.02034F,   //Se agrega F al final para que pase de Double a Float
                Longitude = -73.51640F
            };
            _repoGanadero.AddGanadero(ganadero);
        }

        //Metodo PRUEBA para crear un veterinario en la Base de Datos
        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombre = "Ramiro",
                Apellido = "Mendez",
                NumeroTelefono = "3225671120",
                Direccion = "Carrera 45A No 23B - 123",
                correo = "ramirom@gmail.com",
                contrasena = "123456",
                Latitude = 5.02034F,   //Se agrega F al final para que pase de Double a Float
                Longitude = -73.51640F,
                Registro = "ABCD1234"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        //Crear PRUEBA Metodo para busqueda de ganadero
        private static void BuscarGanadero(int idGanadero)
        {
            var ganadero = _repoGanadero.GetGanadero(idGanadero);
            Console.WriteLine(ganadero.Nombre+" "+ganadero.Apellido);
        }

        private static void GetAll()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Ganaderos");
            var ganaderos = _repoGanadero.GetAllGanaderos();
            foreach(Ganadero item in ganaderos)
            {
                Console.WriteLine(item.Nombre+" "+item.Apellido);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Veterinarios");
            var veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach(Veterinario item in veterinarios)
            {
                Console.WriteLine(item.Nombre+" "+item.Apellido);
            }
        }
    }
}
