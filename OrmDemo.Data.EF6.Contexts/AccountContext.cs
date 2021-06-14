using System.Data.Entity;
using OrmDemo.Data.EF6.Entities;

namespace OrmDemo.Data.EF6.Contexts
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("Host=127.0.0.1;Database=ormef6;Username=postgres;Password=demoserver") { }
        public DbSet<Account> Accounts { get; set; }
    }
}
