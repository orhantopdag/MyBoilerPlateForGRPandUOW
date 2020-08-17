using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Data
{
   public class MRPanelContext:DbContext
    {
        public MRPanelContext(DbContextOptions<MRPanelContext> options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Person>().HasData(new Person { Name = "Mohammad Reza", Family = "Pazooki" });
        }
    }
}
