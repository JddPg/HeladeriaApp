namespace HeladeriaApp.Servicios;

public interface ICrud<T>
{
    void Crear(T obj);
    List<T> Leer();
    void Actualizar(T obj);
    void Eliminar(int id);
}