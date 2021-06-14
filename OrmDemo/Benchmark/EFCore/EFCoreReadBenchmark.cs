using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.EFCore.Services;
using OrmDemo.Data.EFCore.Entities;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.EFCore
{
    public class EFCoreReadBenchmark : ISingleOrmReadBenchmark
    {
        private readonly EFCoreAccountService _service;
        private readonly List<Account> _accounts;

        public EFCoreReadBenchmark()
        {
            _service = new EFCoreAccountService();
            _accounts = EFCoreAccountGenerator.GenerateAccounts(2000);
            _service.InsertMany(_accounts);
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
