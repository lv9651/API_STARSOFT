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
}