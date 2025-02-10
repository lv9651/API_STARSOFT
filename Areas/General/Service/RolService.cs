using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class RolService
    {
        private readonly RolData _data;
        public RolService(RolData data)
        {
            _data = data;
        }

        public async Task<string> ListarRoles(string filtro)
        {
            return JsonConvert.SerializeObject(await _data.ListarRoles(filtro));
        }
        public string ObtenerRolxIdRol(string idrol)
        {
            return JsonConvert.SerializeObject(_data.ObtenerRolxIdRol(idrol));
        }
        public string GuardarEditarRol(string jsonrol)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarRol(jsonrol));
        }
    }
}
