using System;
using System.Collections.Generic;
using OrmDemo.Data.NHibernate.Entities;

namespace OrmDemo.Business.NHibernate.Services.Interfaces
{
    public interface INHibernateAccountService
    {
        List<Account> GetAll();
        Account Get(Guid id);
        void Insert(Account account);
        void InsertMany(List<Account> accounts);
        void InsertManyStateless(List<Account> accounts);
        void Clear();
    }
}
