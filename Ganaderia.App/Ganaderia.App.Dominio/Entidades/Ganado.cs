using System;
using System.ComponentModel.DataAnnotations;
namespace Ganaderia.App.Dominio
{

    public class Ganado
    {
        public int Id { get; set; }
        [Required]
        public int idGanadero { get; set;}
        [Required, StringLength(50)]
        public string raza { get; set; }
        [Required, StringLength(50)]
        public string fechaIngreso { get; set; }
        [Required]
        public int cantidad { get; set; }
    }

}