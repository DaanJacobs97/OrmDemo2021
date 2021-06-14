using System;
using BenchmarkDotNet.Running;
using OrmDemo.Benchmark;
using OrmDemo.Benchmark.Dapper;
using OrmDemo.Benchmark.EF6;
using OrmDemo.Benchmark.EFCore;
using OrmDemo.Benchmark.NHibernate;
using OrmDemo.Business.Dapper.Services;
using OrmDemo.Business.EF6.Services;
using OrmDemo.Business.EFCore.Services;
using OrmDemo.Business.NHibernate.Services;

namespace OrmDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ORM Demo - Daan Jacobs\n");
            Console.WriteLine("1: Dapper Read Benchmark");
            Console.WriteLine("2: Dapper Write Benchmark");
            Console.WriteLine("3: EF Core Read Benchmark");
            Console.WriteLine("4: EF Core Write Benchmark");
            Console.WriteLine("5: EF 6 Read Benchmark");
            Console.WriteLine("6: EF 6 Write Benchmark");
            Console.WriteLine("7: NHibernate Read Benchmark");
            Console.WriteLine("8: NHibernate Write Benchmark");
            Console.WriteLine("9: Full Read Benchmark");
            Console.WriteLine("10: Full Write Benchmark");

            var input = Console.ReadLine();

            if (int.TryParse(input, out var result))
            {
                switch (result)
                {
                    case 1:
                        // Dapper Read
                        BenchmarkRunner.Run<DapperReadBenchmark>();
                        new DapperAccountService().Clear();
                        break;
                    case 2:
                        // Dapper Write
                        BenchmarkRunner.Run<DapperWriteBenchmark>();
                        new DapperAccountService().Clear();
                        break;
                    case 3:
                        // EF Core Read
                        BenchmarkRunner.Run<EFCoreReadBenchmark>();
                        new EFCoreAccountService().Clear();
                        break;
                    case 4:
                        // EF Core Write
                        BenchmarkRunner.Run<EFCoreWriteBenchmark>();
                        new EFCoreAccountService().Clear();
                        break;
                    case 5:
                        // EF 6 Read
                        BenchmarkRunner.Run<EF6ReadBenchmark>();
                        new EF6AccountService().Clear();
                        break;
                    case 6:
                        // EF 6 Write
                        BenchmarkRunner.Run<EF6WriteBenchmark>();
                        new EF6AccountService().Clear();
                        break;
                    case 7:
                        // NHibernate Read
                        BenchmarkRunner.Run<NHibernateReadBenchmark>();
                        new NHibernateAccountService().Clear();
                        break;
                    case 8:
                        // NHibernate Write
                        BenchmarkRunner.Run<NHibernateWriteBenchmark>();
                        new NHibernateAccountService().Clear();
                        break;
                    case 9:
                        // All Read
                        BenchmarkRunner.Run<FullReadBenchmark>();
                        new DapperAccountService().Clear();
                        new EFCoreAccountService().Clear();
                        new EF6AccountService().Clear();
                        new NHibernateAccountService().Clear();
                        break;
                    case 10:
                        // All Write
                        BenchmarkRunner.Run<FullWriteBenchmark>();
                        new DapperAccountService().Clear();
                        new EFCoreAccountService().Clear();
                        new EF6AccountService().Clear();
                        new NHibernateAccountService().Clear();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
