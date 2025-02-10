using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class PermisoService
    {
        private readonly PermisoData _data;
        public PermisoService(PermisoData data)
        {
            _data = data;
        }

        public string ListarPermisosxIdUsuario(string idusuario)
        {
            return JsonConvert.SerializeObject(_data.ListarPermisosxIdUsuario(idusuario));
        }
        public string ListarPermisosxIdRol(string idrol)
        {
            return JsonConvert.SerializeObject(_data.ListarPermisosxIdRol(idrol));
        }
    }
}
