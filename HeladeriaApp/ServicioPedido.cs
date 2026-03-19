public class ServicioPedido : ICrud<Pedido>
{
    private List<Pedido> lista = new();

    public void Crear(Pedido p)
    {
        lista.Add(p);
    }

    public List<Pedido> Leer()
    {
        return lista;
    }

    public void Actualizar(Pedido p)
    {
        var index = lista.FindIndex(x => x.Id == p.Id);
        if (index != -1)
        {
            lista[index] = p;
        }
    }

    public void Eliminar(int id)
    {
        lista.RemoveAll(x => x.Id == id);
    }
}
