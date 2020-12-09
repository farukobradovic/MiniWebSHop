using System;
using System.Collections.Generic;
using System.Text;
using Enterwell_Faruk_Obradovic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enterwell_Faruk_Obradovic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<Stavka> Stavka { get; set; } 
        public DbSet<FakturaStavka> FakturaStavka { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<PDV> PDV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
