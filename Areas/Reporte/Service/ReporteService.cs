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
        public ReporteService(ReporteData data, ClienteData dataCliente)
        {
            _data = data;
            _dataCliente = dataCliente;
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
    }
}
