using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entities;
using System.Diagnostics;

namespace External
{
    public class WW13DbContext : DbContext
    {
        public WW13DbContext()
            : base("DefaultConnection")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}