using System;

namespace OrmDemo.Data.NHibernate.Entities
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
    }
}
