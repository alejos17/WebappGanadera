using Microsoft.EntityFrameworkCore;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set;}
        public DbSet<Ganadero> Ganaderos { get; set;}
        public DbSet<Veterinario> Veterinarios { get; set;}
        public DbSet<Vacuna> Vacunas { get; set;}
        public DbSet<AplicacionVacuna> AplicacionVacunas { get; set;}
        public DbSet<Ganado> Ganado { get; set;}
        public DbSet<Ejemplar> Ejemplares { get; set;}
        public DbSet<AtencionEjemplar> Atenciones { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            //Coneión a Base de Datos Local por defecto para Sistema Windows
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog =GanaderiaBD");
            
            //Conexion a Base de Datos Azure
            //optionsBuilder.UseSqlServer("Server=tcp:mintic2022.database.windows.net,1433;Initial Catalog=GanaderiaBD;Persist Security Info=False;User ID=samintic2022;Password=Alesan.2021az;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //Opcion de Conexión para Base de Datos Remota y Sistema Linux o MAC
            //optionsBuilder.UseSqlServer("Data Source= 192.168.1.2; Initial Catalog =GanaderiaBD;User Id=sa; Password=Alesan.2021");

            
        }
    }

    }
}