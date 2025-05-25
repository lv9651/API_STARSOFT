using STARSOFT_API.Areas.ORDER_COMPRA.Modelo;
using TuProyecto.Repositories;

namespace TuProyecto.Services
{
    public class ImportacionService
    {
        private readonly ImportacionRepository _repository;

        public ImportacionService(ImportacionRepository repository)
        {
            _repository = repository;
        }

        public async Task RegistrarImportacionAsync(ImportacionRequest request)
        {
            await _repository.RegistrarImportacionAsync(request);
        }

        public async Task<ImportacionData> ObtenerPorOrdenCompraAsync(string ordenCompra)
        {
            return await _repository.ObtenerDatosPorOrdenCompraAsync(ordenCompra);
        }

    }
}