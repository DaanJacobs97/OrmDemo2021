using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;
using OrmDemo.Data.Dapper.Entities;
using OrmDemo.Business.Dapper.Services.Interfaces;
using Z.Dapper.Plus;

namespace OrmDemo.Business.Dapper.Services
{
    public class DapperAccountService : IDapperAccountService
    {
        private readonly string _connectionString;

        public DapperAccountService()
        {
            _connectionString = "Host=127.0.0.1;Database=ormdbdapper;Username=postgres;Password=demoserver";
        }

        public List<Account> GetAll()
        {
            using var db = new NpgsqlConnection(_connectionString);
            return db.Query<Account>
                ("SELECT id, firstname, lastname, email FROM Accounts").ToList();
        }

        public Account Get(Guid id)
        {
            using var db = new NpgsqlConnection(_connectionString);
            return db.QueryFirstOrDefault<Account>
                ($"SELECT id, firstname, lastname, email FROM Accounts Where Id = '{id}'");
        }

        public void Insert(Account account)
        {
            using var db = new NpgsqlConnection(_connectionString);
            db.Execute("INSERT INTO Accounts (Id, FirstName, LastName, Email) Values (@Id, @FirstName, @LastName, @Email);", account);
        }

        public void InsertMany(List<Account> accounts)
        {
            using var db = new NpgsqlConnection(_connectionString);
            db.Open();
            db.Execute("INSERT INTO Accounts (Id, FirstName, LastName) Values (@Id, @FirstName, @LastName);",
                accounts);
        }

        public void BulkInsert(List<Account> accounts)
        {
            DapperPlusManager.Entity<Account>().Table("accounts");

            using var db = new NpgsqlConnection(_connectionString);
            db.BulkInsert(accounts);
        }

        public void Clear()
        {
            using var db = new NpgsqlConnection(_connectionString);
            db.Execute("TRUNCATE TABLE Accounts");
        }
    }
}
