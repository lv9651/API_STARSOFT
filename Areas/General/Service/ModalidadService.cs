using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class ModalidadService
    {
        private readonly ModalidadData _data;
        public ModalidadService(ModalidadData data)
        {
            _data = data;
        }

        public string ListarModalidad_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarModalidad_Combo());
        }
    }
}
