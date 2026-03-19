using CsvHelper;
using System.Globalization;

public class ServicioHelado : ICrud<Helado>
{
    private string ruta = Path.Combine(Directory.GetCurrentDirectory(), "..", "Datos", "Helados.csv");

    public void Crear(Helado h)
    {
        var lista = Leer();
        lista.Add(h);
        Guardar(lista);
    }

    public List<Helado> Leer()
    {
        if (!File.Exists(ruta))
            return new List<Helado>();

        using var reader = new StreamReader(ruta);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<Helado>().ToList();
    }

    public void Actualizar(Helado h)
    {
        var lista = Leer();
        var index = lista.FindIndex(x => x.Id == h.Id);

        if (index != -1)
        {
            lista[index] = h;
            Guardar(lista);
        }
    }

    public void Eliminar(int id)
    {
        var lista = Leer();
        lista.RemoveAll(x => x.Id == id);
        Guardar(lista);
    }

    private void Guardar(List<Helado> lista)
    {
        var carpeta = Path.GetDirectoryName(ruta);

        if (!Directory.Exists(carpeta))
            Directory.CreateDirectory(carpeta);

        using var writer = new StreamWriter(ruta);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(lista);
    }
}