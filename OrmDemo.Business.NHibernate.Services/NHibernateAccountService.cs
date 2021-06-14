using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using OrmDemo.Business.NHibernate.Services.Interfaces;
using OrmDemo.Data.NHibernate.Entities;

namespace OrmDemo.Business.NHibernate.Services
{
    public class NHibernateAccountService : INHibernateAccountService
    {
        private readonly ISessionFactory _sessionFactory;

        public NHibernateAccountService()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Host=127.0.0.1;Database=ormdemonhibernate;Username=postgres;Password=demoserver";
                x.Driver<NpgsqlDriver>();
                x.Dialect<PostgreSQL82Dialect>();
            });

            configuration.AddAssembly(Assembly.Load("OrmDemo.Data.NHibernate.Entities"));
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public List<Account> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();

            var accounts = session.CreateCriteria<Account>().List<Account>();
            tx.Commit();

            return accounts.ToList();
        }

        public Account Get(Guid id)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();

            var account = session.Get<Account>(id);
            tx.Commit();

            return account;
        }

        public void Insert(Account account)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();

            session.Save(account);
            tx.Commit();
        }

        public void InsertMany(List<Account> accounts)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            accounts.ForEach(account =>
            {
                session.Save(account);
            });
            tx.Commit();
        }

        public void InsertManyStateless(List<Account> accounts)
        {
            using var session = _sessionFactory.OpenStatelessSession();
            using var tx = session.BeginTransaction();
            accounts.ForEach(account =>
            {
                session.Insert(account);
            });
            tx.Commit();
        }

        public void Clear()
        {
            //using var session = _sessionFactory.OpenSession();
            //using var tx = session.BeginTransaction();

            //session.CreateQuery("TRUNCATE Accounts").ExecuteUpdate();
            //tx.Commit();
        }
    }
}
