using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAuth.Model
{
    class CredContext : DbContext
    {
        public DbSet<Credential> Credentials { get; set; }
    }
}
