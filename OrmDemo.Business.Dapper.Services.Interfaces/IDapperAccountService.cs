using System;
using System.Collections.Generic;
using OrmDemo.Data.Dapper.Entities;

namespace OrmDemo.Business.Dapper.Services.Interfaces
{
    public interface IDapperAccountService
    {
        List<Account> GetAll();
        Account Get(Guid id);
        void Insert(Account account);
        void InsertMany(List<Account> accounts);
        void BulkInsert(List<Account> accounts);
        void Clear();
    }
}
