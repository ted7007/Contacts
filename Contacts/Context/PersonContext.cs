using Contacts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Person>()
                .Property(p => p.sex)
                .HasConversion(
                v => v.ToString(),
                v => (Sex)Enum.Parse(typeof(Sex), v));
        }
    }
}
