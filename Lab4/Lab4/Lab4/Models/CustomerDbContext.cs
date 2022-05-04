using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId=1,
                    Name = "Martin",
                    Age=22,
                    MobileNumber="12345679",

                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 2,
                    Name = "Christopher",
                    Age = 26,
                    MobileNumber = "987654321",

                });
            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   CustomerId=3,
                   Name = "Peter",
                   Age = 76,
                   MobileNumber = "432156789",

               });

            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId=1,
                   Title="An introduction to statistical learning",
                   Author="James",
                   CustomerId=1,
                   Status="Lent"
               });

            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId=2,
                   Title = "How to flip a burger",
                   Author = "Anders svensson",
                   CustomerId =1,
                   Status = "Available"
               });
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId = 3,
                   Title = "How to flip köttbullar",
                   Author = "Olof Parhammar",
                   CustomerId = 2,
                   Status = "Lent"
               });

            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId = 4,
                   Title = "How to become a billionare in 30 minutes",
                   Author = "Reidar Nilssen",
                   CustomerId = 3,
                   Status = "Lent"
               });
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId = 5,
                   Title = "Learn how to run microsoft in 5 minutes",
                   Author = "Bill gates",
                   CustomerId = 3,
                   Status = "Lent"
               });
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   BookId = 6,
                   Title = "Learn how to open a door",
                   Author = "Mark Zuckerberg",
                   CustomerId = 3,
                   Status = "Available"
               });

        }
    }
}
