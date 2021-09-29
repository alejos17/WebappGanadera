namespace Ganaderia.App.Dominio
{

    public class Ganado
    {
        public int Id { get; set; }
        public int idGanadero { get; set;}
        public string raza { get; set; }
        public string fechaIngreso { get; set; }
        public int cantidad { get; set; }
    }

}