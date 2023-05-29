using APLICACION.Models;

namespace APLICACION.Servicios;

public interface IServicioTMDB
{
    enum VentanaTiempo
    {
        day,
        week
    } 
    Task<EnTendencia> todasTendencia(VentanaTiempo dTiempo);
}