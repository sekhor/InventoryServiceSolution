using GraphQL.Types;
using InventoryService.GraphqlMutations;
using InventoryService.Queries;

namespace InventoryService.Schemas
{
    public class CatalogSchema :Schema
    {
        public CatalogSchema(IServiceProvider ServiceProvider)
        {
            Query = ServiceProvider.GetRequiredService<CatalogQuery>();
            Mutation = ServiceProvider.GetRequiredService<CatalogMutation>();
        }
    }
}
