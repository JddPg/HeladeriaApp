public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }

    public int IdCliente { get; set; }
    public string DetallesJson { get; set; }

    [CsvHelper.Configuration.Attributes.Ignore]
    public List<DetallePedido> Detalles
    {
        get => string.IsNullOrEmpty(DetallesJson) ? new() : System.Text.Json.JsonSerializer.Deserialize<List<DetallePedido>>(DetallesJson);
        set => DetallesJson = System.Text.Json.JsonSerializer.Serialize(value);
    }
}