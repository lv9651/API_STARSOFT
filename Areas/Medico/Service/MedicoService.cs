using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Areas.Medico.Data;
using Dapper;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace CLINICA_API.Areas.Medico.Service
{
    public class MedicoService
    {
        private readonly MedicoData _data;
        public MedicoService( MedicoData data) {
            _data= data; 
        }
        public string ListarMedicosxFiltro(string filtro) {
            return JsonConvert.SerializeObject(_data.ListarMedicosxFiltro(filtro));
        }
        public string ObtenerMedicoxIdMedico(string idmedico) {
            return JsonConvert.SerializeObject(_data.ObtenerMedicoxIdMedico(idmedico));
        }
        public string GuardarEditarMedico(string jsonmedico)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarMedico(jsonmedico));
        }
        public string ListarMedicosDisponibles_Combo(string fecha, string idespecialidad, string idmodalidad, string idsucursal)
        {
            return JsonConvert.SerializeObject(_data.ListarMedicosDisponibles_Combo(fecha, idespecialidad, idmodalidad, idsucursal));
        }
        public string ListarMedicosxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarMedicosxFiltro_Modal(filtro));
        }
        public string ObtenerMedicoxNumColegiatura(string numcolegiatura)
        {
            return JsonConvert.SerializeObject(_data.ObtenerMedicoxNumColegiatura(numcolegiatura));
        }
    }
}
