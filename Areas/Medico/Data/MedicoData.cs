using CLINICA_API.Areas.General.Helpers;
using Dapper;

namespace CLINICA_API.Areas.Medico.Data
{
    public class MedicoData
    {
        private readonly ServiceConnection _connection;
        public MedicoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public string GetListaMedicos(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("medico.listarmedicos", parameters);
        }
        public string GetMedicoxid(string idmedico) {
            var parameters = new DynamicParameters();
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("medico.buscarmedicoxid", parameters);
        }
        public async Task<string> GetListasGenerales() {
            return await _connection.MetodoDatatabletostringsqlasync("General.Listas",null);
        }
        public string GuardarEditar(string jsonmedico) {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonmedico", jsonmedico);
            return _connection.MetodoRespuestasql("medico.GuardarEditarMedico", parameters,50);
        }



    }
}
