using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Medico.Data
{
    public class EspecialidadData
    {
        private readonly ServiceConnection _connection;
        public EspecialidadData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarEspecialidad_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_especialidad_combo", parameters);
        }
        public async Task<MensajeJson> ListarEspecialidadXFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("Medico.sp_listar_especialidadxfiltro", parameters);
        }
        public MensajeJson ObtenerEspecialidadxIdEspecialidad(string idespecialidad)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idespecialidad", idespecialidad);
            return _connection.MetodoDatatabletostringsql("Medico.sp_obtener_especialidadxidespecialidad", parameters);
        }
        public MensajeJson GuardarEditarEspecialidad(string jsonespecialidad)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonespecialidad", jsonespecialidad);
            return _connection.MetodoRespuestasql("Medico.sp_guardareditar_especialidad", parameters, 50);
        }
    }
}
