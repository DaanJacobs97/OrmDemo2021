using System.Data.Entity;
using Npgsql;

namespace OrmDemo.Data.EF6.Contexts
{
    public class NpgSqlConfiguration : DbConfiguration
    {
        public NpgSqlConfiguration()
        {
            const string name = "Npgsql";

            SetProviderFactory(providerInvariantName: name,
                providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(providerInvariantName: name,
                provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
        }
    }
}
