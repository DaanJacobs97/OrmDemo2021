using BenchmarkDotNet.Attributes;
using OrmDemo.Benchmark.Interfaces;
using OrmDemo.Business.EFCore.Services;
using OrmDemo.Generators;

namespace OrmDemo.Benchmark.EFCore
{
    public class EFCoreWriteBenchmark : ISingleOrmWriteBenchmark
    {
        private readonly EFCoreAccountService _service;

        public EFCoreWriteBenchmark()
        {
            _service = new EFCoreAccountService();
        }

        [Benchmark]
        public void InsertSingle()
        {
            _service.Insert(EFCoreAccountGenerator.GenerateAccount());
        }

        [Benchmark]
        public void InsertMany()
        {
            _service.InsertMany(EFCoreAccountGenerator.GenerateAccounts(1000));
        }
    }
}
