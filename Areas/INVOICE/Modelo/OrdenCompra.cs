
public class OrdenCompra
{
    public string? CodigoOrdenCompra { get; set; }
    public List<MovimientoContable>? Movimientos { get; set; }
    public List<Detail_Ord_compra>? DatosAdicionales { get; set; }
    public string? MensajeError { get; set; }
}

// Models/MovimientoContable.cs
public class MovimientoContable
{
    public string? glosa { get; set; }
    public DateTime fecha { get; set; }
    public string? subdiarioCodigo { get; set; }
    public string? comprobante { get; set; }
    public string? secuencia { get; set; }

    public string? cuenta { get; set; }
    public string? documento { get; set; }
    public string? fechaDocumento { get; set; }
    public decimal debe { get; set; }

    public string co_c_prove { get; set; }


    public string CO_C_TPDOC { get; set; }
    public string? CO_N_NAMES { get; set; }
    public string CO_C_MONED { get; set; }

}

public class Detail_Ord_compra
{
    public string? codigoorden { get; set; }
    public string? idproducto { get; set; }
    public string? nombre { get; set; }
    public string? cantidad { get; set; }
    public string? total { get; set; }

     public string? UNIDAD_MEDIDA { get; set; }
    public decimal eur_fob { get; set; }
    public string? camoneda { get; set; }


}