using Entities.Concrete;
using Entities.Concrete.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=RentalProjectDb;Integrated Security=true;");
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }
        public DbSet<EmailParameter>? EmailsParameters { get; set; }


        public DbSet<Brand>?Brands { get; set; }    
        public DbSet<Car>? Cars { get; set; }    
        public DbSet<CarImage>? CarImages { get; set; }    
        public DbSet<Color>? Colors { get; set; }    
        public DbSet<CreditCard>? CreditCards { get; set; }    
        public DbSet<Customer>? Customers { get; set; }    
        public DbSet<FindeksService>? FindeksServices { get; set; }    
        public DbSet<Rental>? Rentals { get; set; }    
         

    }
}
