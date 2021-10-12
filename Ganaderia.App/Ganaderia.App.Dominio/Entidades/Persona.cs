using System;
using System.ComponentModel.DataAnnotations;
namespace Ganaderia.App.Dominio
{
    public class Persona
    {
        public int Id { get; set;}
        [Required, StringLength(50)]
        public string Nombre { get; set;}
        [Required, StringLength(50)]
        public string Apellido { get; set;}
        [Required, StringLength(50)]
        public string NumeroTelefono { get; set;}
        [Required, StringLength(50)]
        public string Direccion { get; set;}
        [Required, StringLength(50)]
        public string correo { get; set;}
        [Required, StringLength(50)]
        public string contrasena { get; set;}

    }
}