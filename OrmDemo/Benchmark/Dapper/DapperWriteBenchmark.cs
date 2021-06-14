using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.Dapper.Services;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.Dapper
{
    public class DapperWriteBenchmark : ISingleOrmWriteBenchmark
    {
        private readonly DapperAccountService _service;

        public DapperWriteBenchmark()
        {
            _service = new DapperAccountService();
        }

        [Benchmark]
        public void InsertSingle()
        {
            _service.Insert(DapperAccountGenerator.GenerateAccount());
        }

        [Benchmark]
        public void InsertMany()
        {
            _service.BulkInsert(DapperAccountGenerator.GenerateAccounts(1000));
        }
    }
}
