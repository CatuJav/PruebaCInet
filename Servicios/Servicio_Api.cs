using APLICACION.Models;

namespace APLICACION.Servicios;

using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

public class Servicio_Api:IServicio_Api
{
    private static string _usuario;
    private static string _clave;
    private static string _baseUrl;
    private static string _token;

    public Servicio_Api()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        _usuario = builder.GetSection("ApiSettings:usuario").Value;
        _clave = builder.GetSection("ApiSettings:clave").Value;
        _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;

    }

    public async Task<List<Post>> Lista()
    {
        List<Post> lista = new List<Post>();
        var cliente = new HttpClient();
        cliente.BaseAddress = new Uri(_baseUrl);
        var response = await cliente.GetAsync("posts");

        if (response.IsSuccessStatusCode)
            {
            var json_respuesta = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Post>>(json_respuesta);
            lista = resultado;
        }

        return lista;
    }

    public Task<Post> Obtener(int idProducto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Guardar(Post objeto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Editar(Post objeto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int idProducto)
    {
        throw new NotImplementedException();
    }
}