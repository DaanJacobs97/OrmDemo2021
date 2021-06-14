using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.NHibernate.Services;
using OrmDemo.Data.NHibernate.Entities;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.NHibernate
{
    public class NHibernateReadBenchmark : ISingleOrmReadBenchmark
    {
        private readonly NHibernateAccountService _service;
        private readonly List<Account> _accounts;

        public NHibernateReadBenchmark()
        {
            _service = new NHibernateAccountService();
            _accounts = NHibernateAccountGenerator.GenerateAccounts(1000);
            _service.InsertManyStateless(_accounts);
        }

        [Benchmark]
        public void ReadSingle()
        {
            _service.Get(_accounts[0].Id);
        }

        [Benchmark]
        public void ReadMany()
        {
            _service.GetAll();
        }
    }
}
