using CLINICA_API.Areas.Cita.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class ProcedenciaService
    {
        private readonly ProcedenciaData _data;
        public ProcedenciaService(ProcedenciaData data)
        {
            _data = data;
        }

        public string ListarProcedencia_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarProcedencia_Combo());
        }
    }
}
