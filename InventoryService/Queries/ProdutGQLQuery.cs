using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Queries
{
    public class ProdutGQLQuery : ObjectGraphType<Product>
    {

        public ProdutGQLQuery()
        {
            Name = "Product";
            Field(_ => _.ProductId).Description("Product ID");
                }
    }
}
