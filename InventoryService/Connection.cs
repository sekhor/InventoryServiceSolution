using InventoryService.VaultConfiguration;
using Microsoft.Data.SqlClient;

namespace InventoryService
{
    public static class Connection
    {
        public static String EFConnectionString()
        {
            Dictionary<String, Object> data = new VaultConnection().GetDBCredentials().Result;

            SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
            providerCs.InitialCatalog = "IntelInventoryDb";
            providerCs.UserID = data["username"].ToString();
            providerCs.Password = data["password"].ToString();
            providerCs.DataSource = "WINDOWS-UNR7VLH";

            //providerCs.UserID = CryptoService2.Decrypt(ConfigurationManager.AppSettings["UserId"]);
            providerCs.MultipleActiveResultSets = true;
            providerCs.TrustServerCertificate = false;



            //ecsb.Provider = "System.Data.SqlClient";
            //ecsb.ProviderConnectionString = providerCs.ToString();

            //ecsb.Metadata = string.Format("res://{0}/EDModel.csdl|res://{0}/EDModel.ssdl|res://{0}/EDModel.msl", typeof(Entities).Assembly.FullName);

            return providerCs.ToString();

        }
    }
}
