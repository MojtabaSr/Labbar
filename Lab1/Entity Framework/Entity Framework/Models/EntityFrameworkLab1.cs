using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Models
{
    public  class EntityFrameworkLab1 : DbContext
    {
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Ledighet> Ledighet { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-27H5UGD8;Initial Catalog=EntityFrameworkLab1;Integrated Security=True;");
        }
    }
}
