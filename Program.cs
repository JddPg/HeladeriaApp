var servicioCliente = new ServicioCliente();
var servicioHelado = new ServicioHelado();
var servicioPedido = new ServicioPedido();

// Crear cliente si no existe
if (!servicioCliente.Leer().Any(c => c.Id == 1))
{
    servicioCliente.Crear(new Cliente
    {
        Id = 1,
        Nombre = "Juan Pérez",
        Telefono = "123456789"
    });
}

// Crear helados si no existen
if (!servicioHelado.Leer().Any(h => h.Id == 1))
{
    servicioHelado.Crear(new Helado
    {
        Id = 1,
        Nombre = "Chocolate",
        Precio = 5000,
        NombreSabor = "Chocolate"
    });
}

if (!servicioHelado.Leer().Any(h => h.Id == 2))
{
    servicioHelado.Crear(new Helado
    {
        Id = 2,
        Nombre = "Vainilla",
        Precio = 4000,
        NombreSabor = "Vainilla"
    });
}

// Crear pedido si no existe
if (!servicioPedido.Leer().Any(p => p.Id == 1))
{
    servicioPedido.Crear(new Pedido
    {
        Id = 1,
        Fecha = DateTime.Now,
        IdCliente = 1,
        Detalles = new List<DetallePedido>
        {
            new DetallePedido { Id = 1, IdHelado = 1, Cantidad = 2 },
            new DetallePedido { Id = 2, IdHelado = 2, Cantidad = 1 }
        }
    });
}

// Mostrar datos
Console.WriteLine("=== CLIENTES ===");
var clientes = servicioCliente.Leer();
foreach (var c in clientes)
{
    Console.WriteLine($"{c.Id} - {c.Nombre} - {c.Telefono}");
}

Console.WriteLine("\n=== HELADOS ===");
var helados = servicioHelado.Leer();
foreach (var h in helados)
{
    Console.WriteLine($"{h.Id} - {h.Nombre} - {h.Precio} - {h.NombreSabor}");
}

Console.WriteLine("\n=== PEDIDOS ===");
var pedidos = servicioPedido.Leer();
foreach (var p in pedidos)
{
    Console.WriteLine($"Pedido {p.Id} - Cliente ID: {p.IdCliente} - Fecha: {p.Fecha}");
    foreach (var d in p.Detalles)
    {
        Console.WriteLine($"  Detalle: Helado ID {d.IdHelado} - Cantidad {d.Cantidad}");
    }
}