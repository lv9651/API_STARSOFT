using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.Cita.Data
{
    public class PacienteData
    {
        private readonly ServiceConnection _connection;
        public PacienteData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarPacientexFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_pacientexfiltro", parameters, TipoConexion.SIGE);
        }
        public MensajeJson ObtenerPacientexNumDocumento(string numdocumento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@numdocumento", numdocumento);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_pacientexnumdocumento", parameters, TipoConexion.SIGE);
        }
        public MensajeJson ObtenerPacientexIdPaciente(string idpaciente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idpaciente", idpaciente);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_pacientexidpaciente", parameters, TipoConexion.SIGE);
        }
        public MensajeJson GuardarEditarPaciente(string jsonpaciente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonpaciente", jsonpaciente);
            return _connection.MetodoRespuestasql("Clinica.sp_registrar_actualizar_paciente", parameters, 50, TipoConexion.SIGE);
        }
    }
}
