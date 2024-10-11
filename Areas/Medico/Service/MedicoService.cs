using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Areas.Medico.Data;
using Dapper;
using System.Reflection.Metadata.Ecma335;

namespace CLINICA_API.Areas.Medico.Service
{
    public class MedicoService
    {
        private readonly MedicoData _data;
        public MedicoService( MedicoData data) {
            _data= data; 
        }
        public string GetListaMedicos(string filtro) {
            return _data.GetListaMedicos(filtro);
        }
        public string GetMedicoxid(string idmedico) {
            return _data.GetMedicoxid(idmedico);
        }
        public async Task<string> GetListasGenerales() { 
            return await _data.GetListasGenerales();
        }
        public string GuardarEditar(string jsonmedico) { 
            return _data.GuardarEditar(jsonmedico);
        }
    }
}
