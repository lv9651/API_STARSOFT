using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Venta.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;

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
    }
}