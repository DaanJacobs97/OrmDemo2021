﻿using System;

namespace OrmDemo.Data.EFCore.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
