using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.EF6.Services;
using OrmDemo.Data.EF6.Entities;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.EF6
{
    public class EF6ReadBenchmark : ISingleOrmReadBenchmark
    {
        private readonly EF6AccountService _service;
        private readonly List<Account> _accounts;

        public EF6ReadBenchmark()
        {
            _service = new EF6AccountService();
            _accounts = EF6AccountGenerator.GenerateAccounts(1000);
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
