using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.EF6.Services;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.EF6
{
    public class EF6WriteBenchmark : ISingleOrmWriteBenchmark
    {
        private readonly EF6AccountService _service;

        public EF6WriteBenchmark()
        {
            _service = new EF6AccountService();
        }

        [Benchmark]
        public void InsertSingle()
        {
            _service.Insert(EF6AccountGenerator.GenerateAccount());
        }

        [Benchmark]
        public void InsertMany()
        {
            _service.InsertMany(EF6AccountGenerator.GenerateAccounts(1000));
        }
    }
}
