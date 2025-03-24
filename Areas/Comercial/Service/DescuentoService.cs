using CLINICA_API.Areas.Comercial.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Comercial.Service
{
    public class DescuentoService
    {
        private readonly DescuentoData _data;
        public DescuentoService(DescuentoData data)
        {
            _data = data;
        }

        public string ListarDescuentoxFiltro(string fechainicio, string fechafin, string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarDescuentoxFiltro(fechainicio, fechafin, filtro));
        }
        public string ListarSucursalxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarSucursalxFiltro_Modal(filtro));
        }
        public string ListarListaPrecioxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarListaPrecioxFiltro_Modal(filtro));
        }
        public string ListarTipoProductoxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarTipoProductoxFiltro_Modal(filtro));
        }
        public string ListarProductoxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoxFiltro_Modal(filtro));
        }
        public string ListarClientexFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarClientexFiltro_Modal(filtro));
        }
        public string ListarTipoDescuento_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoDescuento_Combo());
        }
        public string GuardarEditarDescuento(string jsondescuento)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarDescuento(jsondescuento));
        }
        public string ObtenerDescuentoxIdDescuento(string iddescuento)
        {
            return JsonConvert.SerializeObject(_data.ObtenerDescuentoxIdDescuento(iddescuento));
        }
        public string EliminarDescuento(string jsondescuento)
        {
            return JsonConvert.SerializeObject(_data.EliminarDescuento(jsondescuento));
        }
        public string ObtenerDescuentoParaVenta(string idsucursal, string idlistaprecio)
        {
            return JsonConvert.SerializeObject(_data.ObtenerDescuentoParaVenta(idsucursal, idlistaprecio));
        }
    }
}
