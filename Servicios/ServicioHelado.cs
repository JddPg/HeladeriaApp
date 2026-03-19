using HeladeriaApp.Modelo;

namespace HeladeriaApp.Servicios;

public class ServicioHelado : ICrud<Helado>
{
    private List<Helado> lista = new();

    public void Crear(Helado h)
    {
        lista.Add(h);
    }

    public List<Helado> Leer()
    {
        return lista;
    }

    public void Actualizar(Helado h)
    {
        var index = lista.FindIndex(x => x.Id == h.Id);
        if (index != -1)
        {
            lista[index] = h;
        }
    }

    public void Eliminar(int id)
    {
        lista.RemoveAll(x => x.Id == id);
    }
}