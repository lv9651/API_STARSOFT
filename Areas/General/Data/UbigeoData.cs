using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class UbigeoData
    {
        private readonly ServiceConnection _connection;
        public UbigeoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarDepartamentos_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_departamentos_combo", parameters);
        }
        public MensajeJson ListarProvincias_Combo(string iddepartamento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddepartamento", iddepartamento);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_provinciasxiddepartamento_combo", parameters);
        }
        public MensajeJson ListarDistritos_Combo(string idprovincia)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idprovincia", idprovincia);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_distritosxidprovincia_combo", parameters);
        }
    }
}
