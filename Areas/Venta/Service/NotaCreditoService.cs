using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Venta.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;
using System.Data;

namespace CLINICA_API.Areas.Venta.Service
{
    public class NotaCreditoService
    {
        private readonly NotaCreditoData _data;
        private readonly ClienteData _dataCliente;
        public NotaCreditoService(NotaCreditoData data, ClienteData dataCliente)
        {
            _data = data;
            _dataCliente = dataCliente;
        }

        public async Task<string> ListarNotaCreditoXFiltro(string fechainicio, string fechafin, string filtro)
        {
            var msJson = await _data.ListarNotaCreditoXFiltro(fechainicio, fechafin, filtro);
            DataTable dtNotaCredito = new DataTable();
            dtNotaCredito = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtNotaCredito != null)
            {
                if (dtNotaCredito.Rows.Count > 0)
                {
                    Dictionary<string, string?> dIdCliente = new();
                    foreach (DataRow row in dtNotaCredito.Rows)
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
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtNotaCredito)));
        }
        public string ObtenerNotaCreditoxIdNotaCredito(string idnota)
        {
            var msJson = _data.ObtenerNotaCreditoxIdNotaCredito(idnota);
            DataTable dtNC = new DataTable();
            dtNC = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            if (dtNC != null)
            {
                if (dtNC.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtNC.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtNC.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtNC.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                        }
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtNC)));
        }
        public string GuardarEditarNotaCredito(string jsonnotacredito)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarNotaCredito(jsonnotacredito));
        }
        public string ObtenerDatosComprobantexIdNotaCredito(string idventa)
        {
            var msJson = _data.ObtenerDatosComprobantexIdNotaCredito(idventa);
            DataTable dtNC = new DataTable();
            dtNC = JsonConvert.DeserializeObject<DataTable>(msJson.objeto.ToString());
            DataTable dtNCCabecera = JsonConvert.DeserializeObject<DataTable>(dtNC.Rows[0]["NC"].ToString());
            if (dtNCCabecera != null)
            {
                if (dtNCCabecera.Rows.Count > 0)
                {
                    var msJsonCliente = _dataCliente.ObtenerClientexIdCliente(dtNCCabecera.Rows[0]["idcliente"].ToString());
                    DataTable dtCliente = new DataTable();
                    dtCliente = JsonConvert.DeserializeObject<DataTable>(msJsonCliente.objeto.ToString());
                    if (dtCliente != null)
                        if (dtCliente.Rows.Count > 0)
                        {
                            dtNCCabecera.Rows[0]["documentocliente"] = dtCliente.Rows[0]["numdocumento"].ToString();
                            dtNCCabecera.Rows[0]["cliente"] = dtCliente.Rows[0]["cliente"].ToString();
                        }

                    dtNC.Rows[0]["NC"] = JsonConvert.SerializeObject(dtNCCabecera);
                }
            }
            return JsonConvert.SerializeObject(new MensajeJson("OK", JsonConvert.SerializeObject(dtNC)));
        }

    }
}
