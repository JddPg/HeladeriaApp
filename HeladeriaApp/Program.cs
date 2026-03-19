var servicioHelado = new ServicioHelado();


servicioHelado.Crear(new Helado
{
    Id = 1,
    Nombre = "Chocolate",
    Precio = 5000,
    NombreSabor = "Chocolate"
});

servicioHelado.Crear(new Helado
{
    Id = 2,
    Nombre = "Vainilla",
    Precio = 4000,
    NombreSabor = "Vainilla"
});
var lista = servicioHelado.Leer();

Console.WriteLine("=== HELADOS ===");

foreach (var h in lista)
{
    Console.WriteLine($"{h.Id} - {h.Nombre} - {h.Precio} - {h.NombreSabor}");
}