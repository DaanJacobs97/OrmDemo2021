using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.Dapper.Services;
using OrmDemo.Business.EF6.Services;
using OrmDemo.Business.EFCore.Services;
using OrmDemo.Business.NHibernate.Services;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark
{
    [MarkdownExporter]
    public class FullWriteBenchmark : IFullWriteBenchmark
    {
        private readonly DapperAccountService _dapperService;
        private readonly EFCoreAccountService _efCoreService;
        private readonly EF6AccountService _ef6Service;
        private readonly NHibernateAccountService _nHibernateService;

        public FullWriteBenchmark()
        {
            _dapperService = new DapperAccountService();
            _efCoreService = new EFCoreAccountService();
            _ef6Service = new EF6AccountService();
            _nHibernateService = new NHibernateAccountService();
        }

        [Benchmark(Description = "Insert 1 account with Dapper")]
        public void InsertSingleDapper()
        {
            _dapperService.Insert(DapperAccountGenerator.GenerateAccount());
        }

        [Benchmark(Description = "Insert 1 account with EF Core")]
        public void InsertSingleEfCore()
        {
            _efCoreService.Insert(EFCoreAccountGenerator.GenerateAccount());
        }

        [Benchmark(Description = "Insert 1 account with EF6")]
        public void InsertSingleEf6()
        {
            _ef6Service.Insert(EF6AccountGenerator.GenerateAccount());
        }

        [Benchmark(Description = "Insert 1 account with NHibernate")]
        public void InsertSingleNHibernate()
        {
            _nHibernateService.Insert(NHibernateAccountGenerator.GenerateAccount());
        }

        [Benchmark(Description = "Insert 1000 accounts with Dapper")]
        public void InsertManyDapper()
        {
            _dapperService.BulkInsert(DapperAccountGenerator.GenerateAccounts(1000));
        }

        [Benchmark(Description = "Insert 1000 accounts with EF Core")]
        public void InsertManyEfCore()
        {
            _efCoreService.InsertMany(EFCoreAccountGenerator.GenerateAccounts(1000));
        }

        [Benchmark(Description = "Insert 1000 accounts with EF6")]
        public void InsertManyEf6()
        {
            _ef6Service.InsertMany(EF6AccountGenerator.GenerateAccounts(1000));
        }

        [Benchmark(Description = "Insert 1000 accounts with NHibernate")]
        public void InsertManyNHibernate()
        {
            _nHibernateService.InsertMany(NHibernateAccountGenerator.GenerateAccounts(1000));
        }

        [Benchmark(Description = "Insert 1000 accounts stateless with NHibernate")]
        public void InsertManyStatelessNHibernate()
        {
            _nHibernateService.InsertManyStateless(NHibernateAccountGenerator.GenerateAccounts(1000));
        }
    }
}
