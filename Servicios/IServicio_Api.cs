using APLICACION.Models;

namespace APLICACION.Servicios;

public interface IServicio_Api
{
    Task<List<Post>> Lista();
    Task<Post> Obtener(int idProducto);
    Task<bool> Guardar(Post objeto);
    Task<bool> Editar(Post objeto);
    Task<bool> Eliminar(int idProducto);


}