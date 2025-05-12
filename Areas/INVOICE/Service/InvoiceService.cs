public class InvoiceService
{
    private readonly InvoiceRepository _repository;

    public InvoiceService(InvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrdenCompra> ObtenerOrdenCompraPorInvoiceAsync(string invoice)
    {
        if (string.IsNullOrWhiteSpace(invoice))
        {
            throw new ArgumentException("El número de invoice no puede estar vacío");
        }

        return await _repository.ObtenerPorInvoiceAsync(invoice);
    }



    public async Task<IEnumerable<Importacion>> ObtenerImportacionesPorFechaAsync(string fechaInicio, string fechaFin)
    {
        if (string.IsNullOrWhiteSpace(fechaInicio) || string.IsNullOrWhiteSpace(fechaFin))
        {
            throw new ArgumentException("Las fechas no pueden estar vacías");
        }

        return await _repository.ObtenerPorFechaAsync(fechaInicio, fechaFin);
    }



}