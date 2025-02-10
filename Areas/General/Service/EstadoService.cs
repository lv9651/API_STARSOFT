using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class EstadoService
    {
        private readonly EstadoData _data;
        public EstadoService(EstadoData data)
        {
            _data = data;
        }
        public string ListarEstadoxIdGrupoEstado(string idgrupoestado)
        {
            return JsonConvert.SerializeObject(_data.ListarEstadoxIdGrupoEstado(idgrupoestado));
        }
    }
}
