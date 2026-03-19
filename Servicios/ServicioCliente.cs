namespace HeladeriaApp;

public class ServicioCliente : ICrud<Cliente>
{
    private List<Cliente> lista = new();

    public void Crear(Cliente c)
    {
        lista.Add(c);
    }

    public List<Cliente> Leer()
    {
        return lista;
    }

    public void Actualizar(Cliente c)
    {
        var index = lista.FindIndex(x => x.Id == c.Id);
        if (index != -1)
        {
            lista[index] = c;
        }
    }

    public void Eliminar(int id)
    {
        lista.RemoveAll(x => x.Id == id);
    }
}