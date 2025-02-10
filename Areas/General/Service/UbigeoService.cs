using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class UbigeoService
    {
        private readonly UbigeoData _data;
        public UbigeoService(UbigeoData data)
        {
            _data = data;
        }

        public string ListarDepartamentos_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarDepartamentos_Combo());
        }
        public string ListarProvincias_Combo(string iddepartamento)
        {
            return JsonConvert.SerializeObject(_data.ListarProvincias_Combo(iddepartamento));
        }
        public string ListarDistritos_Combo(string idprovincia)
        {
            return JsonConvert.SerializeObject(_data.ListarDistritos_Combo(idprovincia));
        }
    }
}
