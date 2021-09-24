using Microsoft.EntityFrameworkCore;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set;}
        public DbSet<Ganadero> Ganaderos { get; set;}
        public DbSet<Veterinario> Veterinarios { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source= 192.168.1.2; Initial Catalog =GanaderiaBD;User Id=sa; Password=Alesan.2021");

            //optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog =GanaderiaBD");
        }
    }

    }
}