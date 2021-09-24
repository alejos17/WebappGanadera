using System.Collections.Generic;
using Ganaderia.App.Dominio;

namespace Ganaderia.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();

        Veterinario AddVeterinario(Veterinario veterinario);

        Veterinario UpdateVeterinario(Veterinario veterinario);

        void DeleteVeterinario(int idVeterinario);

        Veterinario GetVeterinario(int idVeterinario);
    }
}