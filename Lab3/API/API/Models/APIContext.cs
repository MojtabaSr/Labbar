using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using API.Models;

namespace API.Models
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
       
        public DbSet<Person> Persons { get; set; }
        public DbSet<Intresse> Intresse { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<IntresseLinks> IntresseLinks { get; set; }
        public DbSet<PersonIntresse> PersonIntresse { get; set; }
    }
}
