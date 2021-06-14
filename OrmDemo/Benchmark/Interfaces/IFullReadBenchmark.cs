namespace OrmDemo.Benchmark.Interfaces
{
    public interface IFullReadBenchmark
    {
        void ReadSingleDapper();
        void ReadSingleEfCore();
        void ReadSingleEf6();
        void ReadSingleNHibernate();

        void ReadManyDapper();
        void ReadManyEfCore();
        void ReadManyEf6();
        void ReadManyNHibernate();
    }
}
