using System;
using System.Collections.Generic;
using OrmDemo.Data.Dapper.Entities;

namespace OrmDemo.Generators
{
    public class DapperAccountGenerator : AccountGenerator
    {
        public static Account GenerateAccount()
        {
            return GenerateAccounts(1)[0];
        }

        public static List<Account> GenerateAccounts(int amount)
        {
            if (amount <= 0)
            {
                return null;
            }

            var accounts = new List<Account>();
            for (var i = 0; i < amount; i++)
            {
                var firstName = GenerateName(6);
                var lastName = GenerateName(8);

                accounts.Add(new Account
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = $"{firstName}.{lastName}@demo.com"
                });
            }

            return accounts;
        }
    }
}
