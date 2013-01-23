using HappyPath.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPath.Service.Data.Context
{
    public class HappyPathContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
    }
}
