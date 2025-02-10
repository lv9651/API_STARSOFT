using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class RolPermisoService
    {
        private readonly RolPermisoData _data;
        public RolPermisoService(RolPermisoData data)
        {
            _data = data;
        }

        public string GuardarEditarRolPermiso(string jsonrolpermiso)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarRolPermiso(jsonrolpermiso));
        }
    }
}
