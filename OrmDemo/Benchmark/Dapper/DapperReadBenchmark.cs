using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.Dapper.Services;
using OrmDemo.Data.Dapper.Entities;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.Dapper
{
    public class DapperReadBenchmark : ISingleOrmReadBenchmark
    {
        private readonly DapperAccountService _service;
        private readonly List<Account> _accounts;

        public DapperReadBenchmark()
        {
            _service = new DapperAccountService();
            _accounts = DapperAccountGenerator.GenerateAccounts(1000);
            _service.BulkInsert(_accounts);
        }

        [Benchmark(Description = "Read 1 account")]
        public void ReadSingle()
        {
            _service.Get(_accounts[0].Id);
        }

        [Benchmark(Description = "Read 1000 accounts")]
        public void ReadMany()
        {
            _service.GetAll();
        }
    }
}
