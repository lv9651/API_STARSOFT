using CLINICA_API.Areas.Comercial.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Comercial.Service
{
    public class ListaPreciosService
    {
        private readonly ListaPreciosData _data;
        public ListaPreciosService(ListaPreciosData data)
        {
            _data = data;
        }
        public string ListarListaPrecioxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarListaPrecioxFiltro(filtro));
        }
        public string ObtenerListaPrecioxIdListaPrecio(string idlistaprecio)
        {
            return JsonConvert.SerializeObject(_data.ObtenerListaPrecioxIdListaPrecio(idlistaprecio));
        }
        public string GuardarEditarListaPrecio(string jsonlistaprecios)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarListaPrecio(jsonlistaprecios));
        }
        public string ListarListaPrecioXIdSucursal_Combo(string idsucursal)
        {
            return JsonConvert.SerializeObject(_data.ListarListaPrecioXIdSucursal_Combo(idsucursal));
        }
    }
}
