using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase54
{
    
    class ApplicationContext: DbContext
    {
        public DbSet<Schoolar> schoolars { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
