public class FormulaComponent
{
    public string DescripcionInsumo { get; set; }
    public decimal CantidadInsumo { get; set; }
}

public class DatosCliente
{
    public string nombres { get; set; }
    public string numdocumento { get; set; }

    public string celular { get; set; }
}


public class RecetaCliente
{
    public string idpaciente { get; set; }
    public string edad { get; set; }
    public string peso { get; set; }
    public int idreceta { get; set; }
    public string idcita { get; set; }
    public string nombrereceta { get; set; }
    public int idproducto { get; set; }
    public string descripcionproducto { get; set; }
    public int cantidad { get; set; }
    public string dosis { get; set; }

    public string diagnostico { get; set; }


    public List<DatosCliente> datos_cliente { get; set; }
    
    public List<FormulaComponent> formula { get; set; }
  
}