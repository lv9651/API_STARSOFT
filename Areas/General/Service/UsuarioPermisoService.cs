using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class UsuarioPermisoService
    {
        private readonly UsuarioPermisoData _data;
        public UsuarioPermisoService(UsuarioPermisoData data)
        {
            _data = data;
        }

        public string GuardarEditarUsuarioPermiso(string jsonusuariopermiso)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarUsuarioPermiso(jsonusuariopermiso));
        }
        
    }
}
