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
        //Vacunas
        private static IRepositorioVacuna _repoVacuna = new RepositorioVacuna(new Persistencia.AppContext());
        //Ganado
        private static IRepositorioGanado _repoGanado= new RepositorioGanado(new Persistencia.AppContext());
        //ejemplares
        private static IRepositorioEjemplar _repoEjemplar= new RepositorioEjemplar(new Persistencia.AppContext());
        //AplicacionVacunas
        private static IRepositorioAplicacionVacuna _repoAplicacionVacuna = new RepositorioAplicacionVacuna(new Persistencia.AppContext());
        //AtencionEjemplar
        private static IRepositorioAtencionEjemplar _repoAtencionEjemplar = new RepositorioAtencionEjemplar(new Persistencia.AppContext());

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
            //Añadir Vacuna
            //AddVacuna();
            //Eliminar Vacuna
            //DeleteVacuna(3);
            //AddAplicacionVacuna();
            //AddGanado();
            //AddEjemplar();
            //AddAtencion();

            GetAll();

        }

        //Metodo PRUEBA para crear un ganadero en la Base de Datos
        private static void AddGanadero()
        {
            var ganadero = new Ganadero
            {
                //Id = 34235897,  //Crear atributo para documento de ID
                Nombre = "Alberto",
                Apellido = "Hernandez",
                NumeroTelefono = "3217843627",
                Direccion = "Carrera 58 No 12-34",
                correo = "alberto.h@gmail.com",
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

        private static void AddVacuna()
        {
            var vacuna = new Vacuna
            {
            Nombre = "Otra HA",
            Lote = "012",
            FechaCompra = "26/09/2021",
            FechaVencimiento = "26/09/2023",
            Existencia = 200
            };
            _repoVacuna.AddVacuna(vacuna);
        }

        private static void DeleteVacuna(int idVacuna)
        {
            _repoVacuna.DeleteVacuna(idVacuna);
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
            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Vacunas");
            var vacunas = _repoVacuna.GetAllVacunas();
            foreach(Vacuna item in vacunas)
            {
                Console.WriteLine(item.Nombre+" "+item.Lote);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Ejemplares");
            var ejemplares = _repoEjemplar.GetAllEjemplar();
            foreach(Ejemplar item in ejemplares)
            {
                Console.WriteLine("Vaca Id: "+item.Id+"  Pertenece al Lote de Ganado: "+item.idGanado+"  Raza: "+_repoGanado.GetGanado(item.idGanado).raza+"  Pertenece al Ganadero: "+_repoGanadero.GetGanadero(_repoGanado.GetGanado(item.idGanado).idGanadero).Nombre);
            }
            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Aplicacion de Vacunas");
            var aplicacionVacunas = _repoAplicacionVacuna.GetAllAplicacionVacunas();
            foreach(AplicacionVacuna item in aplicacionVacunas)
            {
                Console.WriteLine(_repoVacuna.GetVacuna(item.idVacuna).Nombre+" La aplico: "+_repoGanadero.GetGanadero(item.idGanadero).Nombre+"");
            }

            Console.WriteLine("****************************************");
            Console.WriteLine("Lista de Atenciones por Ejemplar");
            var atenciones = _repoAtencionEjemplar.GetAllAtenciones();
            foreach(AtencionEjemplar item in atenciones)
            {
                Console.WriteLine("Atención: "+item.Id+"  Fecha: "+item.Fecha+"  Atendido por: "+_repoVeterinario.GetVeterinario(item.idVeterinario).Nombre+"  Estado Actual: "+item.Estado);
            }
        }

        private static void AddGanado()
        {
            var ganado = new Ganado
            {
                idGanadero = 1004,
                raza = "Angus",
                fechaIngreso = "25/04/2021",
                cantidad = 30,
            };
            _repoGanado.AddGanado(ganado);
        }

        private static void AddEjemplar()
        {
            var ejemplar = new Ejemplar
            {
                idGanado = 2,
                fechaCompra = "14/05/2021",
                fechaVacuna = null,
                observaciones = "Problemas gatricos",
                estadoSalud = "Enfermo",
            };
            _repoEjemplar.AddEjemplar(ejemplar);
        }

        private static void AddAplicacionVacuna()
        {
            var aplicacion = new AplicacionVacuna
            {
                idGanadero = 1004,
                idVacuna = 1,
                idEjemplar = 1,
                Fecha = "28/09/2021",
            };
            _repoAplicacionVacuna.AddAplicacionVacuna(aplicacion);
        }

        private static void AddAtencion()
        {
            var atencion = new AtencionEjemplar
            {
                idEjemplar = 2,
                idVeterinario = 5,
                Fecha = "29/09/2021",
                Observaciones = "Animal con problemas respiratorios, se colocan medicamentos, no aplicar vacunación mientras periodo de recuperación.",
                Estado = "En Tratamiento",
            };
            _repoAtencionEjemplar.AddAtencion(atencion);
        } 

    }
}
