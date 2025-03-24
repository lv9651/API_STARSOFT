using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Venta.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace CLINICA_API.Areas.Venta.Service
{
    public class VentaService
    {
        private readonly VentaData _data;
        private readonly PacienteData _dataPaciente;
        private readonly ClienteData _dataCliente;
        public VentaService(VentaData data, PacienteData dataPaciente, ClienteData dataCliente)
        {
            _data = data;
            _dataPaciente = dataPaciente;
            _dataCliente = dataCliente;
        }

        public string ObtenerDatosComprobantexIdVenta(string idventa)
        {
            var msJson = _data.ObtenerDatosComprobantexIdVenta(idventa);
            DataTable dtVenta = new DataTable();
            dtVenta = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            DataTable dtVentaCabecera = JsonConvert.DeserializeObject<DataTable>(dtVenta.Rows[0]["VENTA"].ToString());
            if (dtVentaCabecera != null)
            {
                if (dtVentaCabecera.Rows.Count > 0)
                {
                    var msJsonPaciente = _dataPaciente.ObtenerPacientexIdPaciente(dtVentaCabecera.Rows[0]["idpaciente"].ToString());
                    DataTable dtPaciente = new DataTable();
                    dtPaciente = JsonConvert.DeserializeObject<DataTable>(msJsonPaciente.objeto.ToString());
                    if (dtPaciente != null)
                        if (dtPaciente.Rows.Count > 0)
                        {
                            dtVentaCabecera.Rows[0]["documentopaciente"] = dtPaciente.Rows[0]["numdocumento"].ToString();
                            dtVentaCabecera.Rows[0]["paciente"] = dtPaciente.Rows[0]["paciente"].ToString();
                        }

                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtVentaCabecera.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtVentaCabecera.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtVentaCabecera.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                        }

                    dtVenta.Rows[0]["VENTA"] = JsonConvert.SerializeObject(dtVentaCabecera);
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVenta)));
        }
        public string ObtenerDatosVentaParaCompletarPagoxIdVenta(string idventa)
        {
            var msJson = _data.ObtenerDatosVentaParaCompletarPagoxIdVenta(idventa);
            DataTable dtVenta = new DataTable();
            dtVenta = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtVenta != null)
            {
                if (dtVenta.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtVenta.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtVenta.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtVenta.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVenta)));
        }
        public string GuardarEditarComplementoVentaPago(string jsonventapago)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarComplementoVentaPago(jsonventapago));
        }
        public string ListarVentasNC_Modal(string fechainicio, string fechafin, string idsucursal, string comprobante)
        {
            var msJson = _data.ListarVentasNC_Modal(fechainicio, fechafin, idsucursal, comprobante);
            DataTable dtVenta = new DataTable();
            dtVenta = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtVenta != null)
            {
                if (dtVenta.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdCliente = new();
                    foreach (DataRow row in dtVenta.Rows)
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
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVenta)));
        }
        public string ObtenerDatosVentaParaNCxIdVenta(string idventa)
        {
            var msJson = _data.ObtenerDatosVentaParaNCxIdVenta(idventa);
            DataTable dtVenta = new DataTable();
            dtVenta = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtVenta != null)
            {
                if (dtVenta.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtVenta.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtVenta.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtVenta.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVenta)));
        }
        public DataTable ObtenerDatosVentaNubefact(string idventa)
        {
            var msJson = _data.ObtenerDatosVentaNubefact(idventa);
            DataTable dtVentaNubefact = new DataTable();
            DataTable dtVentaCabecera = new DataTable();
            dtVentaNubefact = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            dtVentaCabecera = JsonConvert.DeserializeObject<DataTable>(dtVentaNubefact.Rows[0]["CABECERA"].ToString());
            if (dtVentaCabecera != null)
            {
                if (dtVentaCabecera.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtVentaCabecera.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtVentaCabecera.Rows[0]["cliente_tipo_de_documento"] = dtCliente.Rows[0]["codigosunat_tipodocumento"].ToString();
                            dtVentaCabecera.Rows[0]["cliente_numero_de_documento"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtVentaCabecera.Rows[0]["cliente_denominacion"] = dtCliente.Rows[0]["cliente"].ToString();
                        }

                    dtVentaNubefact.Rows[0]["CABECERA"] = JsonConvert.SerializeObject(dtVentaCabecera); 
                }
            }
            return dtVentaNubefact;
        }
        public string EnviarJsonVentaNubefact(string idventa)
        {
            DataTable dtRutaToken = new DataTable();
            var msJsonRutaToken = _data.ObtenerRutaTokenSucursalxIdVenta(idventa);
            dtRutaToken = JsonConvert.DeserializeObject<DataTable>(msJsonRutaToken.objeto.ToString());
            string ruta = dtRutaToken.Rows[0]["rutaintegrador"].ToString();//"https://api.nubefact.com/api/v1/3d7b74f1-1187-4fe8-99cb-140e351a7bfe"
            string token = dtRutaToken.Rows[0]["tokenintegrador"].ToString();//"881d5b1d7f7d486698cbd11a75e64fb2687909684db64dacbab79ab84768eccd";
            if (ruta != "1" && token != "1")
            {
                DataTable dtVentaNubefact = ObtenerDatosVentaNubefact(idventa);
                string jsonVentaNubefact = _data.GenerarJsonVentaNubefact(dtVentaNubefact);
                return JsonConvert.SerializeObject(_data.EnviarJsonNubefact(ruta, token, jsonVentaNubefact));
            }
            else
            {
                MensajeJson msJson = new MensajeJson("ERROR", "LA SUCURSAL NO CUENTA CON TOKEN");
                return JsonConvert.SerializeObject(msJson);
            }
        }
        public string EditarTxtGeneradoVenta(string jsonidventa)
        {
            return JsonConvert.SerializeObject(_data.EditarTxtGeneradoVenta(jsonidventa));
        }
        public string ObtenerDatosVentaPagoxIdVenta(string idventa)
        {
            var msJson = _data.ObtenerDatosVentaPagoxIdVenta(idventa);
            DataTable dtVentaVentaPago = new DataTable();
            DataTable dtVenta = new DataTable();
            dtVentaVentaPago = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            dtVenta = JsonConvert.DeserializeObject<DataTable>(dtVentaVentaPago.Rows[0]["VENTA"].ToString());
            if (dtVenta != null)
            {
                if (dtVenta.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtVenta.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtVenta.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtVenta.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                            dtVentaVentaPago.Rows[0]["VENTA"] = JsonConvert.SerializeObject(dtVenta);
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVentaVentaPago)));
        }
        public string EditarVentaPago(string jsonventapago)
        {
            return JsonConvert.SerializeObject(_data.EditarVentaPago(jsonventapago));
        }
        public string ListarVentasVentaPago_Modal(string fechainicio, string fechafin, string idsucursal, string comprobante)
        {
            var msJson = _data.ListarVentasVentaPago_Modal(fechainicio, fechafin, idsucursal, comprobante);
            DataTable dtVenta = new DataTable();
            dtVenta = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtVenta != null)
            {
                if (dtVenta.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdCliente = new();
                    foreach (DataRow row in dtVenta.Rows)
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
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtVenta)));
        }
    }
}