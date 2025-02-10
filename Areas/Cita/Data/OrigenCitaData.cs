using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class OrigenCitaData
    {
        private readonly ServiceConnection _connection;
        public OrigenCitaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarOrigenCita_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_origencita_combo", parameters);
        }
    }
}
