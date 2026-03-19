using CsvHelper;
using System.Globalization;

public class ServicioPedido : ICrud<Pedido>
{
    private string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Datos", "Pedidos.csv");

    public void Crear(Pedido p)
    {
        var lista = Leer();
        lista.Add(p);
        Guardar(lista);
    }

    public List<Pedido> Leer()
    {
        if (!File.Exists(ruta))
            return new List<Pedido>();

        using var reader = new StreamReader(ruta);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<Pedido>().ToList();
    }

    public void Actualizar(Pedido p)
    {
        var lista = Leer();
        var index = lista.FindIndex(x => x.Id == p.Id);
        if (index != -1)
        {
            lista[index] = p;
            Guardar(lista);
        }
    }

    public void Eliminar(int id)
    {
        var lista = Leer();
        lista.RemoveAll(x => x.Id == id);
        Guardar(lista);
    }

    private void Guardar(List<Pedido> lista)
    {
        using var writer = new StreamWriter(ruta);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(lista);
    }
}
