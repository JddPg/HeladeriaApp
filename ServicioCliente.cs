using CsvHelper;
using System.Globalization;

public class ServicioCliente : ICrud<Cliente>
{
    private string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Datos", "Clientes.csv");

    public void Crear(Cliente c)
    {
        var lista = Leer();
        lista.Add(c);
        Guardar(lista);
    }

    public List<Cliente> Leer()
    {
        if (!File.Exists(ruta))
            return new List<Cliente>();

        using var reader = new StreamReader(ruta);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<Cliente>().ToList();
    }

    public void Actualizar(Cliente c)
    {
        var lista = Leer();
        var index = lista.FindIndex(x => x.Id == c.Id);
        if (index != -1)
        {
            lista[index] = c;
            Guardar(lista);
        }
    }

    public void Eliminar(int id)
    {
        var lista = Leer();
        lista.RemoveAll(x => x.Id == id);
        Guardar(lista);
    }

    private void Guardar(List<Cliente> lista)
    {
        using var writer = new StreamWriter(ruta);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(lista);
    }
}