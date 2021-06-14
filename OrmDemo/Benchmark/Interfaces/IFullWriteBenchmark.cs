namespace OrmDemo.Benchmark.Interfaces
{
    public interface IFullWriteBenchmark
    {
        void InsertSingleDapper();
        void InsertSingleEfCore();
        void InsertSingleNHibernate();
        void InsertManyDapper();
        void InsertManyEfCore();
        void InsertManyNHibernate();
    }
}
