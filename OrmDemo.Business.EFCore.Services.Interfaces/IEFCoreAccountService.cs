using System;
using OrmDemo.Data.EFCore.Entities;
using System.Collections.Generic;

namespace OrmDemo.Business.EFCore.Services.Interfaces
{
    public interface IEFCoreAccountService
    {
        List<Account> GetAll();
        Account Get(Guid id);
        void Insert(Account account);
        void InsertMany(List<Account> accounts);
        void Clear();
    }
}
