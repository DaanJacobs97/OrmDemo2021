using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrmDemo.Business.EF6.Services.Interfaces;
using OrmDemo.Data.EF6.Contexts;
using OrmDemo.Data.EF6.Entities;

namespace OrmDemo.Business.EF6.Services
{
    public class EF6AccountService : IEF6AccountService
    {
        public EF6AccountService() { }

        public Account Get(Guid id)
        {
            using var db = new AccountContext();
            return db.Accounts.Where(a => a.Id == id).AsNoTracking().FirstOrDefault();
        }

        public List<Account> GetAll()
        {
            using var db = new AccountContext();
            return db.Accounts.AsNoTracking().ToList();
        }

        public void Insert(Account account)
        {
            using var db = new AccountContext();
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void InsertMany(List<Account> accounts)
        {
            using var db = new AccountContext();
            db.Accounts.AddRange(accounts);
            db.SaveChanges();
        }

        public void Clear()
        {
            using var db = new AccountContext();
            db.Accounts.RemoveRange(db.Accounts);
            db.SaveChanges();
        }
    }
}
