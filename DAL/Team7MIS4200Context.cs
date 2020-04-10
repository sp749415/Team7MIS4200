using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team7MIS4200.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Team7MIS4200.DAL
{
    public class Team7MIS4200Context : DbContext
    {

            public Team7MIS4200Context() : base("name=DefaultConnection")
            {
            // this method is a 'constructor' and is called when a new context is created
            // the base attribute says which connection string to use
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Team7MIS4200Context, Team7MIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
            // Include each object here. The value inside <> is the name of the class,
            // the value outside should generally be the plural of the class name
            // and is the name used to reference the entity in code
            public DbSet<employeeInfo> EmployeeInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<Team7MIS4200.Models.Recognition> Recognitions { get; set; }
    }
    }
