﻿using Microsoft.EntityFrameworkCore;
using storeproject.Models;

namespace storeproject.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        { }
        public DbSet<Users>? User { get; set; }
        public DbSet<Driver>? Driver { get; set; }
        public DbSet<Product>? Product { get; set; }
        public DbSet<RequestItem>? RequestItem { get; set; }
        public DbSet<OrderFile>? OrderFile { get; set; }
        public DbSet<Delivery>? Delivery { get; set; }
        public DbSet<storeproject.Models.ClientAdress>? ClientAdress { get; set; }
        public DbSet<storeproject.Models.Client>? Client { get; set; }
    }
}
