using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class TipoTarjetaService
    {
        private readonly TipoTarjetaData _data;
        public TipoTarjetaService(TipoTarjetaData data)
        {
            _data = data;
        }
        public string ListarTipoTarjeta_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoTarjeta_Combo());
        }
    }
}
