using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class SepetimContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DA06795;Database=Northwind;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CorporateUserAccount> CorporateUserAccounts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<IndividualUserAccount> IndividualUserAccounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<RegisteredCard> RegisteredCards { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
