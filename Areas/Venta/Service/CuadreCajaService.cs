using CLINICA_API.Areas.Venta.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Venta.Service
{
    public class CuadreCajaService
    {
        private readonly CuadreCajaData _data;
        public CuadreCajaService(CuadreCajaData data)
        {
            _data = data;
        }

        public string ListarVentasCuadreCaja(string idusuario, string fechainicio, string fechafin)
        {
            return JsonConvert.SerializeObject(_data.ListarVentasCuadreCaja(idusuario, fechainicio, fechafin));
        }
        public string ValidarGuardarCuadreCaja(string jsoncuadrecaja)
        {
            return JsonConvert.SerializeObject(_data.ValidarGuardarCuadreCaja(jsoncuadrecaja));
        }
        public string ObtenerCuadreCaja(string idcuadrecaja, string idusuario, string fecha)
        {
            return JsonConvert.SerializeObject(_data.ObtenerCuadreCaja(idcuadrecaja, idusuario, fecha));
        }
        public string EditarSegundaParteCuadreCaja(string jsoncuadrecaja)
        {
            return JsonConvert.SerializeObject(_data.EditarSegundaParteCuadreCaja(jsoncuadrecaja));
        }
        public string EditarTerceraParteCuadreCaja(string jsoncuadrecaja)
        {
            return JsonConvert.SerializeObject(_data.EditarTerceraParteCuadreCaja(jsoncuadrecaja));
        }
    }
}
