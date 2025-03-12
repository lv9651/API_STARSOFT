using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Reporte.Data;
using CLINICA_API.Modelo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CLINICA_API.Areas.Reporte.Service
{
    public class ReporteService
    {
        private readonly ReporteData _data;
        private readonly ClienteData _dataCliente;
        private readonly PacienteData _dataPaciente;
        public ReporteService(ReporteData data, ClienteData dataCliente, PacienteData dataPaciente)
        {
            _data = data;
            _dataCliente = dataCliente;
            _dataPaciente = dataPaciente;
        }

        public string ListarCuadreCaja(string idusuario, string idsucursal, string fecha)
        {
            var msJson = _data.ListarCuadreCaja(idusuario, idsucursal, fecha);
            DataTable dtCuadreCaja = new DataTable();
            dtCuadreCaja = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtCuadreCaja != null)
            {
                if (dtCuadreCaja.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdCliente = new();
                    foreach (DataRow row in dtCuadreCaja.Rows)
                    {
                        string? idclientebuscar = row["idcliente"].ToString();
                        string? nombrecliente = "";
                        if (dIdCliente.ContainsKey(idclientebuscar))
                        {
                            nombrecliente = dIdCliente.GetValueOrDefault(idclientebuscar);
                        }
                        else
                        {
                            var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(idclientebuscar);
                            DataTable dtCliente = new DataTable();
                            dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                            if (dtCliente != null)
                                if (dtCliente.Rows.Count > 0)
                                {
                                    nombrecliente = dtCliente.Rows[0]["cliente"].ToString();
                                    dIdCliente.Add(idclientebuscar, nombrecliente);
                                }
                        }

                        row["cliente"] = nombrecliente;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtCuadreCaja)));
        }
        public string ListarProcedimiento(string fechainicio, string fechafin, string idsucursal)
        {
            var msJson = _data.ListarProcedimiento(fechainicio, fechafin, idsucursal);
            DataTable dtProcedimiento = new DataTable();
            dtProcedimiento = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtProcedimiento != null)
            {
                if (dtProcedimiento.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdPaciente = new();
                    foreach (DataRow row in dtProcedimiento.Rows)
                    {
                        string? idpacientebuscar = row["idpaciente"].ToString();
                        string? nombrepaciente = "";
                        if (dIdPaciente.ContainsKey(idpacientebuscar))
                        {
                            nombrepaciente = dIdPaciente.GetValueOrDefault(idpacientebuscar);
                        }
                        else
                        {
                            var msJsonCliente = _dataPaciente.ObtenerPacientexIdPaciente(idpacientebuscar);
                            DataTable dtCliente = new DataTable();
                            dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                            if (dtCliente != null)
                                if (dtCliente.Rows.Count > 0)
                                {
                                    nombrepaciente = dtCliente.Rows[0]["paciente"].ToString();
                                    dIdPaciente.Add(idpacientebuscar, nombrepaciente);
                                }
                        }

                        row["paciente"] = nombrepaciente;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtProcedimiento)));
        }
        public string ListarNumeroConsultas(string fechainicio, string fechafin, string idmedico)
        {
            return JsonConvert.SerializeObject(_data.ListarNumeroConsultas(fechainicio, fechafin, idmedico));
        }
        public string ListarVentasDetallado(string fechainicio, string fechafin, string idsucursal, string comprobante)
        {
            var msJson = _data.ListarVentasDetallado(fechainicio, fechafin, idsucursal, comprobante);
            DataTable dtVentasDetallado = new DataTable();
            dtVentasDetallado = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtVentasDetallado != null)
            {
                if (dtVentasDetallado.Rows.Count > 0)
                {
                    Dictionary<string, string[]> dIdPaciente = new();
                    Dictionary<string, string[]> dIdCliente = new();
                    foreach (DataRow row in dtVentasDetallado.Rows)
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

                        //Cliente
                        string? idclientebuscar = row["idcliente"].ToString();
                        string? documentocliente = "";
                        string? nombrecliente = "";
                        if (dIdCliente.ContainsKey(idclientebuscar))
                        {
                            string[] aDatosCliente = dIdCliente.GetValueOrDefault(idclientebuscar);
                            documentocliente = aDatosCliente[0];
                            nombrecliente = aDatosCliente[1];
                        }
                        else
                        {
                            var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(idclientebuscar);
                            DataTable dtCliente = new DataTable();
                            dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                            if (dtCliente != null)
                                if (dtCliente.Rows.Count > 0)
                                {
                                    string[] aDatosCliente = new string[2];
                                    documentocliente = dtCliente.Rows[0]["numdocumento"].ToString();
                                    nombrecliente = dtCliente.Rows[0]["cliente"].ToString();
                                    aDatosCliente[0] = documentocliente;
                                    aDatosCliente[1] = nombrecliente;
                                    dIdCliente.Add(idclientebuscar, aDatosCliente);
                                }
                        }

                        row["documentopaciente"] = documentopaciente;
                        row["paciente"] = nombrepaciente;
                        row["documentocliente"] = documentocliente;
                        row["cliente"] = nombrecliente;
                    }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVentasDetallado)));
        }
    }
}
