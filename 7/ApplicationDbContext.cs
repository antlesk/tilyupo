using _7.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("InterpolConnection")
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<Crime> Crimes { get; set; }
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<CriminalOrganization> CriminalOrganizations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
