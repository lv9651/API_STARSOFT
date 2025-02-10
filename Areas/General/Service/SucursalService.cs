using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class SucursalService
    {
        private readonly SucursalData _data;
        public SucursalService(SucursalData data)
        {
            _data = data;
        }
        public string ListarSucursalxIdEmpresa_Combo(string idempresa)
        {
            return JsonConvert.SerializeObject(_data.ListarSucursalxIdEmpresa_Combo(idempresa));
        }
        public string ListarSucuralxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarSucuralxFiltro(filtro));
        }
        public string ObtenerSucursalxIdSucursal(string idsucursal)
        {
            return JsonConvert.SerializeObject(_data.ObtenerSucursalxIdSucursal(idsucursal));
        }
        public string GuardarEditarSucursal(string jsonsucursal)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarSucursal(jsonsucursal));
        }
        public string GuardarEditarListaPrecioSucursal(string jsonlistapreciosucursal)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarListaPrecioSucursal(jsonlistapreciosucursal));
        }
        public string GuardarEditarCorrelativoSucursal(string jsoncorrelativosucursal)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarCorrelativoSucursal(jsoncorrelativosucursal));
        }
        public string ListarCorrelativoxIdSucursal(string idsucursal)
        {
            return JsonConvert.SerializeObject(_data.ListarCorrelativoxIdSucursal(idsucursal));
        }
    }
}
