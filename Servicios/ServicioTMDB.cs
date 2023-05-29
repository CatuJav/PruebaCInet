using System.Net.Http.Headers;
using APLICACION.Models;
using Newtonsoft.Json;



namespace APLICACION.Servicios
{
    public class ServicioTMDB:IServicioTMDB
    {
        private string _baseUrl;
        private string _token;
        public ServicioTMDB()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:basetmdb").Value;
            _token = builder.GetSection("ApiSettings:apiKey").Value;
        }
        public async Task<EnTendencia> todasTendencia(IServicioTMDB.VentanaTiempo dTiempo)
        {
            EnTendencia resultado=null;
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_token);
                var resp = await cliente.GetAsync(String.Format("trending/all/{0}?language=es-ES", dTiempo));
                if (resp.IsSuccessStatusCode)
                {
                    var contenido =await resp.Content.ReadAsStringAsync();
                    
                    resultado = JsonConvert.DeserializeObject<EnTendencia>(contenido);
                }

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
