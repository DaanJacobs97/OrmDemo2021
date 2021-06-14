using System;
using System.Collections.Generic;
using OrmDemo.Data.EF6.Entities;

namespace OrmDemo.Business.EF6.Services.Interfaces
{
    public interface IEF6AccountService
    {
        List<Account> GetAll();
        Account Get(Guid id);
        void Insert(Account account);
        void InsertMany(List<Account> accounts);
        void Clear();
    }
}
