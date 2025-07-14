using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditApplication.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<CreditApply> CreditApplications { get; set; }
        public DbSet<Client> Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditApply>()
                .ToTable("CreditApplications")
                .HasOne(cp => cp.Client)
                .WithMany(c => c.CreditApplies)
                .HasForeignKey(cp => cp.IdClient);
        }
    }

    }
