using System.Threading.Tasks;
namespace STARSOFT_API.Areas.ORDER_COMPRA.Modelo
{
    public interface IImportacionRepository
    {
        Task RegistrarImportacionAsync(ImportacionRequest request);
    }
}
