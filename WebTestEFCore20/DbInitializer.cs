using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestEFCore20.Models;

namespace WebTestEFCore20
{
    public static class DbInitializer
    {
        public static void Initialize(TestDbContext context) //SchoolContext is EF context
        {

            context.Database.EnsureCreated(); //if db is not exist ,it will create database .but ,do nothing .

            Person ivanov = null;
            Person petrov = null;
            LegalEntity corns = null;

            if (!context.Persons.Any())
            {
                ivanov = new Person {Family = "Иванов", Name = "Андрей"};
                petrov = new Person {Family = "Петров", Name = "Сергей"};
                context.Persons.Add(ivanov);
                context.Persons.Add(petrov);
            }
            if (!context.LegalEntities.Any())
            {
                corns = new LegalEntity {Name = "Рога и копыта", LegalType = "ООО"};
                context.LegalEntities.Add(corns);
            }

            if (!context.Accounts.Any())
            {
                Account acc5678 = new Account {Number = 5678, Owner = ivanov, Saldo = 900};
                Account acc7876 = new Account {Number = 7876, Owner = corns, Saldo = 100};
                Account acc7656 = new Account {Number = 7656, Owner = petrov, Saldo = 200};

                context.Accounts.Add(acc5678);
                context.Accounts.Add(acc7656);
                context.Accounts.Add(acc7876);
            }

            context.SaveChanges();
        }
    }
}
