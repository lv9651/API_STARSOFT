using CLINICA_API.Areas.General.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;

namespace CLINICA_API.Areas.General.Service
{
    public class ConstanteService
    {
        private readonly ConstanteData _data;
        public ConstanteService(ConstanteData data)
        {
            _data = data;
        }

        public async Task<string> ListasGenerales()
        {
            try
            {
                MensajeJson msJsonCli = await _data.ListasGenerales();
                DataTable dtCli = new DataTable();
                dtCli = JsonConvert.DeserializeObject<DataTable>(msJsonCli.objeto.ToString());
                MensajeJson msJsonRetornar = new MensajeJson("OK", dtCli);
                return JsonConvert.SerializeObject(msJsonRetornar);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ObtenerConstantexDescripcion(string descripcion)
        {
            return JsonConvert.SerializeObject(_data.ObtenerConstantexDescripcion(descripcion));
        }
    }
}
