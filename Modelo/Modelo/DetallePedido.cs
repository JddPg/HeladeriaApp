namespace HeladeriaApp.Modelo;

public class DetallePedido
{
    public int Id { get; set; }
    public Helado Helado { get; set; }
    public int Cantidad { get; set; }
}