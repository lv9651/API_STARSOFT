using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;

namespace CLINICA_API.Areas.Venta.Data
{
    public class NotaCreditoData
    {
        private readonly ServiceConnection _connection;
        public NotaCreditoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public async Task<MensajeJson> ListarNotaCreditoXFiltro(string fechainicio, string fechafin, string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("Ventas.sp_listar_notacreditoxfiltro", parameters);
        }
        public MensajeJson ObtenerNotaCreditoxIdNotaCredito(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_notacreditoxidnota", parameters);
        }
        public MensajeJson GuardarEditarNotaCredito(string jsonnotacredito)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonnotacredito", jsonnotacredito);
            return _connection.MetodoRespuestasql("Ventas.sp_guardareditar_notacredito", parameters, 50);
        }
        public MensajeJson ObtenerDatosComprobantexIdNotaCredito(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datoscomprobantexidnota", parameters);
        }
        public MensajeJson ObtenerRutaTokenSucursalxIdNota(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_rutatokensucursalxidnota", parameters);
        }
        public MensajeJson ObtenerDatosNotaNubefact(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datosnotanubefact", parameters);
        }
        public string GenerarJsonNotaNubefact(DataTable dtNotaNubefact)
        {
            DataTable dtNota = new DataTable();
            DataTable dtNotaDetalle = new DataTable();
            DataTable dtNotaPago = new DataTable();

            dtNota = JsonConvert.DeserializeObject<DataTable>(dtNotaNubefact.Rows[0]["CABECERA"].ToString());
            dtNotaDetalle = JsonConvert.DeserializeObject<DataTable>(dtNotaNubefact.Rows[0]["DETALLE"].ToString());
            dtNotaPago = JsonConvert.DeserializeObject<DataTable>(dtNotaNubefact.Rows[0]["PAGO"].ToString());

            var jsonObject = new
            {
                operacion = dtNota.Rows[0]["operacion"].ToString().Trim(),
                tipo_de_comprobante = dtNota.Rows[0]["tipo_de_comprobante"].ToString().Trim(),
                serie = dtNota.Rows[0]["serie"].ToString().Trim(),
                numero = dtNota.Rows[0]["numero"].ToString().Trim(),
                sunat_transaction = dtNota.Rows[0]["sunat_transaccion"].ToString().Trim(),
                cliente_tipo_de_documento = dtNota.Rows[0]["cliente_tipo_de_documento"].ToString().Trim(),
                cliente_numero_de_documento = dtNota.Rows[0]["cliente_numero_de_documento"].ToString().Trim(),
                cliente_denominacion = dtNota.Rows[0]["cliente_denominacion"].ToString().Trim(),
                cliente_direccion = dtNota.Rows[0]["cliente_direccion"].ToString().Trim(),
                cliente_email = dtNota.Rows[0]["cliente_email"].ToString().Trim(),
                cliente_email_1 = dtNota.Rows[0]["cliente_email2"].ToString().Trim(),
                cliente_email_2 = dtNota.Rows[0]["cliente_email2"].ToString().Trim(),
                fecha_de_emision = dtNota.Rows[0]["fecha_de_emision"].ToString().Trim(),
                fecha_de_vencimiento = dtNota.Rows[0]["fecha_de_vencimiento"].ToString().Trim(),
                moneda = dtNota.Rows[0]["moneda"].ToString().Trim(),
                tipo_de_cambio = dtNota.Rows[0]["tipo_de_cambio"].ToString().Trim(),
                porcentaje_de_igv = dtNota.Rows[0]["porcentaje_de_igv"].ToString().Trim(),
                descuento_global = dtNota.Rows[0]["descuento_global"].ToString().Trim(),
                total_descuento = dtNota.Rows[0]["total_descuento"].ToString().Trim(),
                total_anticipo = dtNota.Rows[0]["total_anticipo"].ToString().Trim(),
                total_gravada = dtNota.Rows[0]["total_gravada"].ToString().Trim(),
                total_inafecta = dtNota.Rows[0]["total_inafecta"].ToString().Trim(),
                total_exonerada = dtNota.Rows[0]["total_exonerada"].ToString().Trim(),
                total_igv = dtNota.Rows[0]["total_igv"].ToString().Trim(),
                total_impuestos_bolsas = dtNota.Rows[0]["total_impuestos_bolsas"].ToString().Trim(),
                total_gratuita = dtNota.Rows[0]["total_gratuita"].ToString().Trim(),
                total_otros_cargos = dtNota.Rows[0]["total_otros_cargos"].ToString().Trim(),
                total = dtNota.Rows[0]["total"].ToString().Trim(),
                percepcion_tipo = dtNota.Rows[0]["percepcion_tipo"].ToString().Trim(),
                percepcion_base_imponible = dtNota.Rows[0]["percepcion_base_imponible"].ToString().Trim(),
                total_percepcion = dtNota.Rows[0]["total_percepcion"].ToString().Trim(),
                total_incluido_percepcion = dtNota.Rows[0]["total_incluido_percepcion"].ToString().Trim(),
                detraccion = Convert.ToBoolean(dtNota.Rows[0]["detraccion"]),
                observaciones = dtNota.Rows[0]["observaciones"].ToString().Trim(),
                documento_que_se_modifica_tipo = dtNota.Rows[0]["documento_que_se_modifica_tipo"].ToString().Trim(),
                documento_que_se_modifica_serie = dtNota.Rows[0]["documento_que_se_modifica_serie"].ToString().Trim(),
                documento_que_se_modifica_numero = dtNota.Rows[0]["documento_que_se_modifica_numero"].ToString().Trim(),
                tipo_de_nota_de_credito = dtNota.Rows[0]["tipo_de_nota_de_credito"].ToString().Trim(),
                tipo_de_nota_de_debito = dtNota.Rows[0]["tipo_de_nota_de_debito"].ToString().Trim(),
                enviar_automaticamente_a_la_sunat = Convert.ToBoolean(dtNota.Rows[0]["enviar_automaticamente_a_la_sunat"]),
                enviar_automaticamente_al_cliente = Convert.ToBoolean(dtNota.Rows[0]["enviar_automaticamente_al_cliente"]),
                codigo_unico = dtNota.Rows[0]["codigo_unico"].ToString().Trim(),
                condiciones_de_pago = dtNota.Rows[0]["condiciones_de_pago"].ToString().Trim(),
                medio_de_pago = dtNota.Rows[0]["medio_de_pago"].ToString().Trim(),
                placa_vehiculo = dtNota.Rows[0]["placa_vehiculo"].ToString().Trim(),
                orden_compra_servicio = dtNota.Rows[0]["orden_compra_servicio"].ToString().Trim(),
                formato_de_pdf = dtNota.Rows[0]["formato_de_pdf"].ToString().Trim(),
                detraccion_tipo = dtNota.Rows[0]["detraccion_tipo"].ToString().Trim(),
                detraccion_total = dtNota.Rows[0]["detraccion_total"].ToString().Trim(),
                detraccion_porcentaje = dtNota.Rows[0]["detraccion_porcentaje"].ToString().Trim(),
                medio_de_pago_detraccion = dtNota.Rows[0]["medio_de_pago_detraccion"].ToString().Trim(),
                generado_por_contingencia = dtNota.Rows[0]["generado_por_contingencia"].ToString().Trim(),
                items = dtNotaDetalle.Rows.Cast<DataRow>().Select(row => new
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
                    anticipo = row["anticipo"].ToString(),
                    serie_anticipo = row["serie_anticipo"].ToString(),
                    doc_anticipo = row["doc_anticipo"].ToString(),
                    codigo_excel = row["codigo_excel"].ToString(),
                    otro_cargos = row["otro_cargos"].ToString(),
                    ISC = row["ISC"].ToString(),
                    impuesto_bolsa = row["impuesto_bolsa"].ToString(),
                }).ToList(),
                venta_al_credito = dtNotaPago.Rows.Cast<DataRow>().Select(row => new
                {
                    cuota = row["cuotas"].ToString(),
                    fecha_de_pago = row["fecha_vencimiento"].ToString(),
                    importe = row["total"].ToString()
                }).ToList()
            };

            string jsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            return jsonResult;
        }
        public MensajeJson EnviarJsonNubefact(string url, string token, string jsonnota)
        {
            try
            {
                WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
                //byte[] json_bytes = Encoding.Default.GetBytes(jsonventa);
                //string json_en_utf_8 = Encoding.UTF8.GetString(json_bytes);

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                cliente.Headers[HttpRequestHeader.Authorization] = "Token token=" + token;

                var json_respuesta = cliente.UploadString(url, "POST", jsonnota);
                return new MensajeJson("OK", "EL COMPROBANTE FUE CARGADO CORRECTAMENTE");
            }
            catch (WebException ex)
            {
                var respuesta = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                return new MensajeJson("ERROR", respuesta);
            }
        }
        public MensajeJson EditarTxtGeneradoNota(string jsonidnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonidnota", jsonidnota);
            return _connection.MetodoRespuestasql("Ventas.sp_editar_txtgeneradonota", parameters, 50);
        }
    }
}
