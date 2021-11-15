using InventoryService.Models;

namespace InventoryService.Repositories
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(long id);

        bool DeleteProduct(long id);
    }
}
