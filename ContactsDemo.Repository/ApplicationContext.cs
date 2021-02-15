using ContactsDemo.Domain;
using ContactsDemo.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Repository
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> builder) : base(builder)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<LegalPerson> LegalPeople { get; set; }
        public DbSet<NaturalPerson> NaturalPeople { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
