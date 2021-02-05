using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactsDemoWebApp.Models;

namespace ContactsDemoWebApp.Data
{
    public class ContactsDemoWebAppContext : DbContext
    {
        public ContactsDemoWebAppContext (DbContextOptions<ContactsDemoWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ContactsDemoWebApp.Models.LegalPersonContactViewModel> LegalPersonContactViewModel { get; set; }

        public DbSet<ContactsDemoWebApp.Models.NaturalPersonContactViewModel> NaturalPersonContactViewModel { get; set; }
    }
}
