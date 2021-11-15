using InventoryService.Models;

namespace InventoryService.Repositories
{
    public interface ICatalogRepository
    {
        Catalog AddCatalog(Catalog catalog);
        IEnumerable<Catalog> GetAllCatalogs();
        
        Catalog GetCatalogById(long id);

        bool DeleteCatalog(long id);


    }
}
