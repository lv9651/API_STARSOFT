using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;

namespace CLINICA_API.Areas.Venta.Data
{
    public class VentaData
    {
        private readonly ServiceConnection _connection;
        public VentaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ObtenerDatosComprobantexIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datoscomprobantexidventa", parameters);
        }
        public MensajeJson ObtenerDatosVentaParaCompletarPagoxIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datosventaparacompletarpagoxidventa", parameters);
        }
        public MensajeJson GuardarEditarComplementoVentaPago(string jsonventapago)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonventapago", jsonventapago);
            return _connection.MetodoRespuestasql("Ventas.sp_guardareditar_complementoventapago", parameters, 50);
        }
        public MensajeJson ListarVentasNC_Modal(string fechainicio, string fechafin, string idsucursal, string comprobante)
        {
            fechainicio = fechainicio.Replace("-", "/");
            fechafin = fechafin.Replace("-", "/");
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@comprobante", comprobante);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_listar_ventasncxfiltro", parameters);
        }
        public MensajeJson ObtenerDatosVentaParaNCxIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datosventaparancxidventa", parameters);
        }
        public MensajeJson ObtenerRutaTokenSucursalxIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_rutatokensucursalxidventa", parameters);
        }
        public MensajeJson ObtenerDatosVentaNubefact(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datosventanubefact", parameters);
        }
        public string GenerarJsonVentaNubefact(DataTable dtVentaNubefact)
        {
            DataTable dtVenta = new DataTable();
            DataTable dtVentaDetalle = new DataTable();
            DataTable dtVentaPago = new DataTable();

            dtVenta = JsonConvert.DeserializeObject<DataTable>(dtVentaNubefact.Rows[0]["CABECERA"].ToString());
            dtVentaDetalle = JsonConvert.DeserializeObject<DataTable>(dtVentaNubefact.Rows[0]["DETALLE"].ToString());
            dtVentaPago = JsonConvert.DeserializeObject<DataTable>(dtVentaNubefact.Rows[0]["PAGO"].ToString());

            var jsonObject = new
            {
                operacion = dtVenta.Rows[0]["operacion"].ToString().Trim(),
                tipo_de_comprobante = dtVenta.Rows[0]["tipo_de_comprobante"].ToString().Trim(),
                serie = dtVenta.Rows[0]["serie"].ToString().Trim(),
                numero = dtVenta.Rows[0]["numero"].ToString().Trim(),
                sunat_transaction = dtVenta.Rows[0]["sunat_transaccion"].ToString().Trim(),
                cliente_tipo_de_documento = dtVenta.Rows[0]["cliente_tipo_de_documento"].ToString().Trim(),
                cliente_numero_de_documento = dtVenta.Rows[0]["cliente_numero_de_documento"].ToString().Trim(),
                cliente_denominacion = dtVenta.Rows[0]["cliente_denominacion"].ToString().Trim(),
                cliente_direccion = dtVenta.Rows[0]["cliente_direccion"].ToString().Trim(),
                cliente_email = dtVenta.Rows[0]["cliente_email"].ToString().Trim(),
                cliente_email2 = dtVenta.Rows[0]["cliente_email2"].ToString().Trim(),
                fecha_de_emision = dtVenta.Rows[0]["fecha_de_emision"].ToString().Trim(),
                fecha_de_vencimiento = dtVenta.Rows[0]["fecha_de_vencimiento"].ToString().Trim(),
                moneda = dtVenta.Rows[0]["moneda"].ToString().Trim(),
                tipo_de_cambio = dtVenta.Rows[0]["tipo_de_cambio"].ToString().Trim(),
                porcentaje_de_igv = dtVenta.Rows[0]["porcentaje_de_igv"].ToString().Trim(),
                descuento_global = dtVenta.Rows[0]["descuento_global"].ToString().Trim(),
                total_descuento = dtVenta.Rows[0]["total_descuento"].ToString().Trim(),
                total_anticipo = dtVenta.Rows[0]["total_anticipo"].ToString().Trim(),
                total_gravada = dtVenta.Rows[0]["total_gravada"].ToString().Trim(),
                total_inafecta = dtVenta.Rows[0]["total_inafecta"].ToString().Trim(),
                total_exonerada = dtVenta.Rows[0]["total_exonerada"].ToString().Trim(),
                total_igv = dtVenta.Rows[0]["total_igv"].ToString().Trim(),
                total_gratuita = dtVenta.Rows[0]["total_gratuita"].ToString().Trim(),
                total_otros_cargos = dtVenta.Rows[0]["total_otros_cargos"].ToString().Trim(),
                total = dtVenta.Rows[0]["total"].ToString().Trim(),
                percepcion_tipo = dtVenta.Rows[0]["percepcion_tipo"].ToString().Trim(),
                percepcion_base_imponible = dtVenta.Rows[0]["percepcion_base_imponible"].ToString().Trim(),
                total_percepcion = dtVenta.Rows[0]["total_percepcion"].ToString().Trim(),
                total_incluido_percepcion = dtVenta.Rows[0]["total_incluido_percepcion"].ToString().Trim(),
                detraccion = Convert.ToBoolean(dtVenta.Rows[0]["detraccion"]),
                observaciones = dtVenta.Rows[0]["observaciones"].ToString().Trim(),
                documento_que_se_modifica_tipo = dtVenta.Rows[0]["documento_que_se_modifica_tipo"].ToString().Trim(),
                documento_que_se_modifica_serie = dtVenta.Rows[0]["documento_que_se_modifica_serie"].ToString().Trim(),
                documento_que_se_modifica_numero = dtVenta.Rows[0]["documento_que_se_modifica_numero"].ToString().Trim(),
                tipo_de_nota_de_credito = dtVenta.Rows[0]["tipo_de_nota_de_credito"].ToString().Trim(),
                tipo_de_nota_de_debito = dtVenta.Rows[0]["tipo_de_nota_de_debito"].ToString().Trim(),
                enviar_automaticamente_a_la_sunat = Convert.ToBoolean(dtVenta.Rows[0]["enviar_automaticamente_a_la_sunat"]),
                enviar_automaticamente_al_cliente = Convert.ToBoolean(dtVenta.Rows[0]["enviar_automaticamente_al_cliente"]),
                codigo_unico = dtVenta.Rows[0]["codigo_unico"].ToString().Trim(),
                condiciones_de_pago = dtVenta.Rows[0]["condiciones_de_pago"].ToString().Trim(),
                medio_de_pago = dtVenta.Rows[0]["medio_de_pago"].ToString().Trim(),
                placa_vehiculo = dtVenta.Rows[0]["placa_vehiculo"].ToString().Trim(),
                orden_compra_servicio = dtVenta.Rows[0]["orden_compra_servicio"].ToString().Trim(),
                formato_de_pdf = dtVenta.Rows[0]["formato_de_pdf"].ToString().Trim(),
                generado_por_contingencia = dtVenta.Rows[0]["generado_por_contingencia"].ToString().Trim(),
                items = dtVentaDetalle.Rows.Cast<DataRow>().Select(row => new
                {
                    unidad_de_medida = row["medida"].ToString(),
                    codigo = row["codigoproducto"].ToString(),
                    descripcion = row["producto"].ToString(),
                    cantidad = row["cantidad"].ToString(),
                    valor_unitario = row["valor_unitario"].ToString(),
                    precio_unitario = row["precio_unitario"].ToString(),
                    descuento = row["descuento"].ToString(),
                    subtotal = row["subtotal"].ToString(),
                    tipo_de_igv = row["tipo_igv"].ToString(),
                    igv = row["total_igv"].ToString(),
                    total = row["total"].ToString(),
                    anticipo_regularizacion = Convert.ToBoolean(row["anticipo_regularizacion"]),
                    anticipo_documento_serie = row["anticipo_documento_serie"].ToString(),
                    anticipo_documento_numero = row["anticipo_documento_numero"].ToString(),
                    codigo_producto_sunat = row["codigo_producto_sunat"].ToString()
                }).ToList(),
                venta_al_credito = dtVentaPago.Rows.Cast<DataRow>().Select(row => new
                {
                    cuota = row["cuotas"].ToString(),
                    fecha_de_pago = row["fecha_vencimiento"].ToString(),
                    importe = row["total"].ToString()
                }).ToList()
            };

            string jsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            return jsonResult;
        }
        public MensajeJson EnviarJsonNubefact(string url, string token, string jsonventa)
        {
            try
            {
                WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
                //byte[] json_bytes = Encoding.Default.GetBytes(jsonventa);
                //string json_en_utf_8 = Encoding.UTF8.GetString(json_bytes);

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                cliente.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;

                var json_respuesta = cliente.UploadString(url, "POST", jsonventa);
                return new MensajeJson("OK", "EL COMPROBANTE FUE CARGADO CORRECTAMENTE");
            }
            catch (WebException ex)
            {
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                return new MensajeJson("ERROR", respuesta);
            }
        }
        public MensajeJson EditarTxtGeneradoVenta(string jsonidventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonidventa", jsonidventa);
            return _connection.MetodoRespuestasql("Ventas.sp_editar_txtgeneradoventa", parameters, 50);
        }
    }
}