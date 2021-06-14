using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.NHibernate.Services;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.NHibernate
{
    public class NHibernateWriteBenchmark : ISingleOrmWriteBenchmark
    {
        private readonly NHibernateAccountService _service;

        public NHibernateWriteBenchmark()
        {
            _service = new NHibernateAccountService();
        }

        [Benchmark]
        public void InsertSingle()
        {
            _service.Insert(NHibernateAccountGenerator.GenerateAccount());
        }

        [Benchmark]
        public void InsertMany()
        {
            _service.InsertMany(NHibernateAccountGenerator.GenerateAccounts(1000));
        }

        [Benchmark]
        public void InsertManyStateless()
        {
            _service.InsertManyStateless(NHibernateAccountGenerator.GenerateAccounts(1000));
        }
    }
}
