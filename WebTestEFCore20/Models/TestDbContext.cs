using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebTestEFCore20.Models
{

    public class TestDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LegalEntity> LegalEntities { get; set; }
        public DbSet<Person> Persons { get; set; }


        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }


    public class Account
    {
        public int Id { get; set; }

        public AccountOwner Owner { get; set; }
        public long Number { get; set; }
        public decimal Saldo { get; set; }
    }

    [NotMapped]
    public abstract class AccountOwner
    {
        public int Id { get; set; }

        public string OwnerType => GetOwnerType();
        public string OwnerName => GetOwnerName();

        protected abstract string GetOwnerType();
        protected abstract string GetOwnerName();

    }

    public class LegalEntity : AccountOwner
    {
        public string Name { get; set; }
        public string LegalType { get; set; }

        protected override string GetOwnerType()
        {
            return "юр";
        }

        protected override string GetOwnerName()
        {
            return Name;
        }
    }

    public class Person : AccountOwner
    {
        public string Family { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }


        protected override string GetOwnerType()
        {
            return "физ";
        }

        protected override string GetOwnerName()
        {
            return $"{Family} {Name}";
        }
    }

}
