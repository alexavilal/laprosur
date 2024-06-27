namespace SIGA.Entities.Comunes
{

    public enum TipoErrorServicioDtoResponse
    {

        ErrorNoManejado = 0,

        ErrorBaseDatos = 1,

        AccesoDenegado = 2,

        ErrorTiempoConexion = 3,

        ErrorNegocio = 4,

        ErrorSeguridad = 5,

        ErrorConexionWs = 6,

        ErrorProtocoloWs = 7
    }
}
