using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrmDemo.Data.EFCore.Contexts;
using OrmDemo.Data.EFCore.Entities;
using OrmDemo.Business.EFCore.Services.Interfaces;

namespace OrmDemo.Business.EFCore.Services
{
    public class EFCoreAccountService : IEFCoreAccountService
    {
        public EFCoreAccountService() { }

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
