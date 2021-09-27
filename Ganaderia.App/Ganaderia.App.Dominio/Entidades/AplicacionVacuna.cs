namespace Ganaderia.App.Dominio 
{
    public class AplicacionVacuna
    {
        public int Id { get; set; }
        public int idGanadero { get; set;}
        public int idVacuna { get; set;}
        public int idEjemplar { get; set;}
        public string Fecha { get; set;}
        
    }
}