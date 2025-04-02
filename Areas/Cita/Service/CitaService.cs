using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;

namespace CLINICA_API.Areas.Cita.Service
{
    public class CitaService
    {
        private readonly CitaData _data;
        private readonly PacienteData _dataPaciente;
        private readonly ClienteData _dataCliente;
        public CitaService(CitaData data, PacienteData dataPaciente, ClienteData dataCliente)
        {
            _data = data;
            _dataPaciente = dataPaciente;
            _dataCliente = dataCliente;
        }
        public string ListarCitaxFiltro(string fechainicio, string fechafin, string modalidad, string idsucursal)
        {
            MensajeJson msJson = _data.ListarCitaxFiltro(fechainicio, fechafin, modalidad, idsucursal);
            DataTable dtCita = new DataTable();
            dtCita = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtCita != null)
            {
                if (dtCita.Rows.Count > 0)
                {
                    Dictionary<string, string[]> dIdPaciente = new();
                    foreach (DataRow row in dtCita.Rows)
                    {
                        //Paciente
                        string? idpacientebuscar = row["idpaciente"].ToString();
                        string? nombrepaciente = "";
                        string? telefono = "";
                        if (dIdPaciente.ContainsKey(idpacientebuscar))
                        {
                            string[] aDatosPaciente = dIdPaciente.GetValueOrDefault(idpacientebuscar);
                            nombrepaciente = aDatosPaciente[0];
                            telefono = aDatosPaciente[1];
                        }
                        else
                        {
                            var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(idpacientebuscar);
                            DataTable dtPaciente = new DataTable();
                            dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                            if (dtPaciente != null)
                                if (dtPaciente.Rows.Count > 0)
                                {
                                    string[] aDatosPaciente = new string[2];
                                    nombrepaciente = dtPaciente.Rows[0]["paciente"].ToString();
                                    telefono = dtPaciente.Rows[0]["telefono"].ToString();
                                    aDatosPaciente[0] = nombrepaciente;
                                    aDatosPaciente[1] = telefono;
                                    dIdPaciente.Add(idpacientebuscar, aDatosPaciente);
                                }
                        }

                        row["paciente"] = nombrepaciente;
                        row["telefono"] = telefono;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtCita)));
        }
        public string GuardarEditarCita(string jsoncita)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarCita(jsoncita));
        }
        public string ListarCitaAtenderxFiltro(string fechainicio, string fechafin, string idmedico)
        {
            MensajeJson msJson = _data.ListarCitaAtenderxFiltro(fechainicio, fechafin, idmedico);
            DataTable dtCita = new DataTable();
            dtCita = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtCita != null)
            {
                if (dtCita.Rows.Count > 0)
                {
                    Dictionary<string, string[]> dIdPaciente = new();
                    foreach (DataRow row in dtCita.Rows)
                    {
                        //Paciente
                        string? idpacientebuscar = row["idpaciente"].ToString();
                        string? documentopaciente = "";
                        string? nombrepaciente = "";
                        if (dIdPaciente.ContainsKey(idpacientebuscar))
                        {
                            string[] aDatosPaciente = dIdPaciente.GetValueOrDefault(idpacientebuscar);
                            documentopaciente = aDatosPaciente[0];
                            nombrepaciente = aDatosPaciente[1];
                        }
                        else
                        {
                            var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(idpacientebuscar);
                            DataTable dtPaciente = new DataTable();
                            dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                            if (dtPaciente != null)
                                if (dtPaciente.Rows.Count > 0)
                                {
                                    string[] aDatosPaciente = new string[2];
                                    documentopaciente = dtPaciente.Rows[0]["numdocumento"].ToString();
                                    nombrepaciente = dtPaciente.Rows[0]["paciente"].ToString();
                                    aDatosPaciente[0] = documentopaciente;
                                    aDatosPaciente[1] = nombrepaciente;
                                    dIdPaciente.Add(idpacientebuscar, aDatosPaciente);
                                }
                        }

                        row["documentopaciente"] = documentopaciente;
                        row["paciente"] = nombrepaciente;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtCita)));
        }
        public string GuardarEditarCitaAtender(string jsoncita)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarCitaAtender(jsoncita));
        }
        public string ObtenerCitaAtenderxIdCita(string idcita)
        {
            var msJsonProcedimiento = _data.ObtenerCitaAtenderxIdCita(idcita);
            DataTable dtCita = new DataTable();
            dtCita = JsonConvert.DeserializeObject<DataTable>(msJsonProcedimiento.objeto.ToString());
            if (dtCita != null)
            {
                if (dtCita.Rows.Count > 0)
                {
                    var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(dtCita.Rows[0]["idpaciente"].ToString());
                    DataTable dtPaciente = new DataTable();
                    dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                    if (dtPaciente != null)
                        if (dtPaciente.Rows.Count > 0)
                        {
                            dtCita.Rows[0]["documentopaciente"] = dtPaciente.Rows[0]["numdocumento"].ToString();
                            dtCita.Rows[0]["paciente"] = dtPaciente.Rows[0]["paciente"].ToString();
                            dtCita.Rows[0]["fechanacimiento"] = dtPaciente.Rows[0]["fechanacimiento"].ToString();
                            dtCita.Rows[0]["edad"] = dtPaciente.Rows[0]["edad"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtCita)));
        }
        public string GuardarCitaArchivo(string jsoncitaarchivo)
        {
            return JsonConvert.SerializeObject(_data.GuardarCitaArchivo(jsoncitaarchivo));
        }
        public string EliminarCitaArchivo(string idcitaarchivo)
        {
            return JsonConvert.SerializeObject(_data.EliminarCitaArchivo(idcitaarchivo));
        }
        public string ObtenerHistorialClinicoxIdPaciente(string idpaciente)
        {
            MensajeJson msJson = _data.ObtenerHistorialClinicoxIdPaciente(idpaciente);
            DataTable dtHistorialClinico = new DataTable();
            dtHistorialClinico = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtHistorialClinico != null)
            {
                if (dtHistorialClinico.Rows.Count > 0)
                {
                    string idapoderado = dtHistorialClinico.Rows[0]["idapoderado"].ToString();
                    if (idapoderado != "0")
                    {
                        var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(idapoderado);
                        DataTable dtApoderado = new DataTable();
                        dtApoderado = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                        if (dtApoderado != null)
                            if (dtApoderado.Rows.Count > 0)
                            {
                                dtHistorialClinico.Rows[0]["numdocumentoapoderado"] = dtApoderado.Rows[0]["numdocumento"].ToString();
                                dtHistorialClinico.Rows[0]["apoderado"] = dtApoderado.Rows[0]["cliente"].ToString();
                            }
                    }

                    var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(dtHistorialClinico.Rows[0]["idpaciente"].ToString());
                    DataTable dtPaciente = new DataTable();
                    dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                    if (dtPaciente != null)
                        if (dtPaciente.Rows.Count > 0)
                        {
                            dtHistorialClinico.Rows[0]["documentopaciente"] = dtPaciente.Rows[0]["numdocumento"].ToString();
                            dtHistorialClinico.Rows[0]["paciente"] = dtPaciente.Rows[0]["paciente"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtHistorialClinico)));
        }
        public string ObtenerCitaxIdCita_ModalCitasPaciente(string idcita)
        {
            return JsonConvert.SerializeObject(_data.ObtenerCitaxIdCita_ModalCitasPaciente(idcita));
        }
        public string ObtenerDatosRecetaxIdReceta_FormatoReceta(string idcitaarchivo)
        {
            var msJson = _data.ObtenerDatosRecetaxIdReceta_FormatoReceta(idcitaarchivo);
            DataTable dtTabla = new DataTable();
            dtTabla = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtTabla != null)
            {
                if (dtTabla.Rows.Count > 0)
                {
                    var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(dtTabla.Rows[0]["idpaciente"].ToString());
                    DataTable dtPaciente = new DataTable();
                    dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                    if (dtPaciente != null)
                        if (dtPaciente.Rows.Count > 0)
                        {
                            dtTabla.Rows[0]["documento"] = dtPaciente.Rows[0]["numdocumento"].ToString();
                            dtTabla.Rows[0]["paciente"] = dtPaciente.Rows[0]["paciente"].ToString();
                            dtTabla.Rows[0]["telefono"] = dtPaciente.Rows[0]["telefono"].ToString();
                            dtTabla.Rows[0]["edad"] = dtPaciente.Rows[0]["edad"].ToString();
                        }
                }
            }

            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtTabla)));
        }
        public string ObtenerDisponibilidadCitaxIdCita(string idcita)
        {
            return JsonConvert.SerializeObject(_data.ObtenerDisponibilidadCitaxIdCita(idcita));
        }
        public string ReprogramarCita(string jsonreprogramarcita)
        {
            return JsonConvert.SerializeObject(_data.ReprogramarCita(jsonreprogramarcita));
        }
        public string EstadoNoRealizado(string jsoncita)
        {
            return JsonConvert.SerializeObject(_data.EstadoNoRealizado(jsoncita));
        }
        public string ObtenerRecetaxIdReceta(string idreceta)
        {
            return JsonConvert.SerializeObject(_data.ObtenerRecetaxIdReceta(idreceta));
        }
        public string ListarProductoTerminadoxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoTerminadoxFiltro(filtro));
        }
        public string ListarFormulaRapidaxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarFormulaRapidaxFiltro(filtro));
        }
        public string ObtenerComposicionProductoXIdFormula(string idformula)
        {
            return JsonConvert.SerializeObject(_data.ObtenerComposicionProductoXIdFormula(idformula));
        }
        public string GuardarEditarReceta(string jsonreceta)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarReceta(jsonreceta));
        }
        public string EliminarReceta(string idreceta)
        {
            return JsonConvert.SerializeObject(_data.EliminarReceta(idreceta));
        }
        public string ListarInsumoxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarInsumoxFiltro(filtro));
        }
        public string EditarHistorialClinico(string jsonhistorialclinico)
        {
            return JsonConvert.SerializeObject(_data.EditarHistorialClinico(jsonhistorialclinico));
        }
        public string ObtenerHistorialClinico_ModalxIdPaciente(string idpaciente, string idcita)
        {
            MensajeJson msJson = _data.ObtenerHistorialClinico_ModalxIdPaciente(idpaciente, idcita);
            DataTable dtHistorialClinico = new DataTable();
            dtHistorialClinico = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtHistorialClinico != null)
            {
                if (dtHistorialClinico.Rows.Count > 0)
                {
                    var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(dtHistorialClinico.Rows[0]["idpaciente"].ToString());
                    DataTable dtPaciente = new DataTable();
                    dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                    if (dtPaciente != null)
                        if (dtPaciente.Rows.Count > 0)
                        {
                            dtHistorialClinico.Rows[0]["documentopaciente"] = dtPaciente.Rows[0]["numdocumento"].ToString();
                            dtHistorialClinico.Rows[0]["paciente"] = dtPaciente.Rows[0]["paciente"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtHistorialClinico)));
        }
        public string GuardarEditarCitaNutricionPsicologia(string jsoncita)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarCitaNutricionPsicologia(jsoncita));
        }
        public string EstadoAtendida(string jsoncita)
        {
            return JsonConvert.SerializeObject(_data.EstadoAtendida(jsoncita));
        }
        public string ListarInterconsulta_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarInterconsulta_Combo());
        }
        public string ListarProductoxIdTipoProducto_Combo(string idtipoproducto)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoxIdTipoProducto_Combo(idtipoproducto));
        }
    }
}
