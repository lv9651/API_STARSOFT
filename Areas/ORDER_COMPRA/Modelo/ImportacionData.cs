namespace STARSOFT_API.Areas.ORDER_COMPRA.Modelo
{
    public class ImportacionData
    {
        public List<TablaInvoice> TablaInvoice { get; set; }
        public List<TablaCaltimereal> TablaCaltimereal { get; set; }
        public List<TablaDua> TablaDua { get; set; }
        public List<DistribucionFinal> DistribucionFinal { get; set; }
    }

    public class TablaInvoice
    {
        public string OrdenCompra { get; set; }
        public string ID_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad_Medida { get; set; }
        public decimal EUR_FOB { get; set; }
        public decimal USD_FOB { get; set; }
        public decimal Flete_USD { get; set; }
        public decimal Seguro_USD { get; set; }
        public decimal Total_USD { get; set; }
        public decimal ADV { get; set; }
        public decimal Total { get; set; }
    }

    public class TablaCaltimereal
    {
        public string OrdenCompra { get; set; }
        public decimal Porc_FOB { get; set; }
        public decimal Porc_Flete { get; set; }
        public decimal Porc_Seguro { get; set; }
        public decimal Porc_ADV { get; set; }
    }

    public class TablaDua
    {
        public string OrdenCompra { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Serie_Numero { get; set; }
        public decimal Importe { get; set; }
        public string Tipo_Moneda { get; set; }
        public decimal TC { get; set; }
    }

    public class DistribucionFinal
    {
        public string OrdenCompra { get; set; }
        public string Descripcion_Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal FOB_OC { get; set; }
        public decimal FOB_S { get; set; }
        public decimal Flete { get; set; }
        public decimal Seguro { get; set; }
        public decimal ADV { get; set; }
        public decimal Handling { get; set; }
        public decimal Gastos_Operativos { get; set; }
        public decimal gastos_Administrativos { get; set; }

        public decimal Almacenaje { get; set; }
        public decimal Serv_Logistico { get; set; }
        public decimal Otros_Gastos { get; set; }
        public decimal Costo_Total { get; set; }
        public decimal Costo_Unit { get; set; }
        public decimal Porc_Participacion { get; set; }
    }
}