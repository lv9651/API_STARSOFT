using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Medico.Data
{
    public class HorarioMedicoData
    {
        private readonly ServiceConnection _connection;
        public HorarioMedicoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarMedico_modalHorarioMedico(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_medicoxfiltro_modalhorariomedico", parameters);
        }
        public MensajeJson ListarHorarioMedicoxIdMedico(string idmedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_horariomedicoxidmedico", parameters);
        }
        public MensajeJson ObtenerHorarioMedicoxIdHorarioMedico(string idhorariomedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idhorariomedico", idhorariomedico);
            return _connection.MetodoDatatabletostringsql("Medico.sp_obtener_horariomedicoxidhorariomedico", parameters);
        }
        public MensajeJson GuardarEditarHorarioMedico(string jsonhorariomedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonhorariomedico", jsonhorariomedico);
            return _connection.MetodoRespuestasql("Medico.sp_guardareditar_horariomedico", parameters, 50);
        }
        public MensajeJson ListarHorarioMedicoDivididoxFechaxIdMedico_Combo(string fecha, string idmodalidad, string idsucursal, string idmedico)
        {
            fecha = fecha.Replace("-", "/");
            var parameters = new DynamicParameters();
            parameters.Add("@fecha", fecha);
            parameters.Add("@idmodalidad", idmodalidad);
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_horariomedicodividicoxfechaxidmedico_combo", parameters);
        }
    }
}
