using CLINICA_API.Areas.Producto.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Producto.Service
{
    public class TipoProductoService
    {
        private readonly TipoProductoData _data;
        public TipoProductoService(TipoProductoData data)
        {
            _data = data;
        }
        
        public string ListarTipoProductoxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarTipoProductoxFiltro(filtro));
        }
        public string ObtenerTipoProductoxIdTipoProducto(string idtipoproducto)
        {
            return JsonConvert.SerializeObject(_data.ObtenerTipoProductoxIdTipoProducto(idtipoproducto));
        }
        public string GuardarEditarTipoProducto(string jsontipoproducto)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarTipoProducto(jsontipoproducto));
        }
        public string ListarTipoProducto_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoProducto_Combo());
        }
    }
}
