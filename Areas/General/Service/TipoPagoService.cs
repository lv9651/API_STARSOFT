using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class TipoPagoService
    {
        private readonly TipoPagoData _data;
        public TipoPagoService(TipoPagoData data)
        {
            _data = data;
        }
        public string ListarTipoPago_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoPago_Combo());
        }
    }
}
