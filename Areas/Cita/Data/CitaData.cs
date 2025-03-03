using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class CitaData
    {
        private readonly ServiceConnection _connection;
        public CitaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarCitaxFiltro(string fechainicio, string fechafin, string modalidad, string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@modalidad", modalidad);
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_citasxfiltro", parameters);
        }
        public MensajeJson GuardarEditarCita(string jsoncita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncita", jsoncita);
            return _connection.MetodoRespuestasql("Citas.sp_guardareditar_cita", parameters, 50);
        }
        public MensajeJson ListarCitaAtenderxFiltro(string fechainicio, string fechafin, string idmedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_citasatenderxfiltro", parameters);
        }
        public MensajeJson GuardarEditarCitaAtender(string jsoncita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncita", jsoncita);
            return _connection.MetodoRespuestasql("Citas.sp_guardareditar_citaatender", parameters, 50);
        }
        public MensajeJson ObtenerCitaAtenderxIdCita(string idcita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcita", idcita);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_citaatenderxidcita", parameters);
        }
        public MensajeJson GuardarCitaArchivo(string jsoncitaarchivo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncitaarchivo", jsoncitaarchivo);
            return _connection.MetodoRespuestasql("Citas.sp_guardareditar_citaarchivo", parameters, 50);
        }
        public MensajeJson EliminarCitaArchivo(string idcitaarchivo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcitaarchivo", idcitaarchivo);
            return _connection.MetodoRespuestasql("Citas.sp_eliminar_citaarchivo", parameters, 50);
        }
        public MensajeJson ObtenerHistorialClinicoxIdPaciente(string idpaciente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idpaciente", idpaciente);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_historialclinicoxidpaciente", parameters);
        }
        public MensajeJson ObtenerCitaxIdCita_ModalCitasPaciente(string idcita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcita", idcita);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_citaxidcita_modalcitaspaciente", parameters);
        }
        public MensajeJson ObtenerDatosRecetaxIdReceta_FormatoReceta(string idreceta)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idreceta", idreceta);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_datosrecetaxidreceta_formatoreceta", parameters);
        }
        public MensajeJson ObtenerDisponibilidadCitaxIdCita(string idcita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcita", idcita);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_disponibilidadcitaxidcita", parameters);
        }
        public MensajeJson ReprogramarCita(string jsonreprogramarcita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonreprogramarcita", jsonreprogramarcita);
            return _connection.MetodoRespuestasql("Citas.sp_reprogramar_cita", parameters, 50);
        }
        public MensajeJson EstadoNoRealizado(string jsoncita)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncita", jsoncita);
            return _connection.MetodoRespuestasql("Citas.sp_editar_estadocitanorealizado", parameters, 50);
        }
        public MensajeJson ObtenerRecetaxIdReceta(string idreceta)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idreceta", idreceta);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_recetaxidreceta", parameters);
        }
        public MensajeJson ListarProductoTerminadoxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_productosterminadosxfiltro", parameters, ServiceConnection.TipoConexion.SISLAB);
        }
        public MensajeJson ListarFormulaRapidaxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_formulasrapidasxfiltro", parameters, ServiceConnection.TipoConexion.SISLAB);
        }
        public MensajeJson ObtenerComposicionProductoXIdFormula(string idformula)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idformula", idformula);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_composicionproductoxidformula", parameters, ServiceConnection.TipoConexion.SISLAB);
        }
        public MensajeJson GuardarEditarReceta(string jsonreceta)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonreceta", jsonreceta);
            return _connection.MetodoRespuestasql("Citas.sp_guardar_receta", parameters, 50, ServiceConnection.TipoConexion.Clinica);
        }
        public MensajeJson EliminarReceta(string idreceta)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idreceta", idreceta);
            return _connection.MetodoRespuestasql("Citas.sp_eliminar_receta", parameters, 50);
        }
        public MensajeJson ListarInsumoxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_insumosxfiltro", parameters, ServiceConnection.TipoConexion.SISLAB);
        }
    }
}
