using CLINICA_API.Areas.Comercial.Data;
using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class EmpresaService
    {
        private readonly EmpresaData _data;
        public EmpresaService(EmpresaData data)
        {
            _data = data;
        }

        public string ListarEmpresa_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarEmpresa_Combo());
        }
    }
}
