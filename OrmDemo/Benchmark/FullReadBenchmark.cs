using System.Collections.Generic;
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
    public class FullReadBenchmark : IFullReadBenchmark
    {
        private readonly DapperAccountService _dapperService;
        private readonly List<Data.Dapper.Entities.Account> _dapperAccounts;
        private readonly EFCoreAccountService _efCoreService;
        private readonly List<Data.EFCore.Entities.Account> _efCoreAccounts;
        private readonly EF6AccountService _ef6Service;
        private readonly List<Data.EF6.Entities.Account> _ef6Accounts;
        private readonly NHibernateAccountService _nHibernateService;
        private readonly List<Data.NHibernate.Entities.Account> _nHibernateAccounts;

        public FullReadBenchmark()
        {
            _dapperService = new DapperAccountService();
            _dapperAccounts = DapperAccountGenerator.GenerateAccounts(1000);
            _dapperService.BulkInsert(_dapperAccounts);

            _efCoreService = new EFCoreAccountService();
            _efCoreAccounts = EFCoreAccountGenerator.GenerateAccounts(1000);
            _efCoreService.InsertMany(_efCoreAccounts);

            _ef6Service = new EF6AccountService();
            _ef6Accounts = EF6AccountGenerator.GenerateAccounts(1000);
            _ef6Service.InsertMany(_ef6Accounts);

            _nHibernateService = new NHibernateAccountService();
            _nHibernateAccounts = NHibernateAccountGenerator.GenerateAccounts(1000);
            _nHibernateService.InsertManyStateless(_nHibernateAccounts);
        }

        #region ReadSingle

        [Benchmark(Description = "Read 1 account with Dapper")]
        public void ReadSingleDapper()
        {
            _dapperService.Get(_dapperAccounts[0].Id);
        }

        [Benchmark(Description = "Read 1 account with EF Core")]
        public void ReadSingleEfCore()
        {
            _efCoreService.Get(_efCoreAccounts[0].Id);
        }

        [Benchmark(Description = "Read 1 account with EF6")]
        public void ReadSingleEf6()
        {
            _ef6Service.Get(_ef6Accounts[0].Id);
        }

        [Benchmark(Description = "Read 1 account with NHibernate")]
        public void ReadSingleNHibernate()
        {
            _nHibernateService.Get(_nHibernateAccounts[0].Id);
        }

        #endregion

        #region ReadMany

        [Benchmark(Description = "Read 1000 accounts with Dapper")]
        public void ReadManyDapper()
        {
            _dapperService.GetAll();
        }

        [Benchmark(Description = "Read 1000 accounts with EF Core")]
        public void ReadManyEfCore()
        {
            _efCoreService.GetAll();
        }

        [Benchmark(Description = "Read 1000 accounts with EF6")]
        public void ReadManyEf6()
        {
            _ef6Service.GetAll();
        }

        [Benchmark(Description = "Read 1000 accounts with NHibernate")]
        public void ReadManyNHibernate()
        {
            _nHibernateService.GetAll();
        }

        #endregion
    }
}
