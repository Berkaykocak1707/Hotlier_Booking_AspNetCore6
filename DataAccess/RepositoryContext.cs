using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms
        {
            get; set;
        }
        public DbSet<Booking> Bookings
        {
            get; set;
        }
        public DbSet<Contact> Contacts
        {
            get; set;
        }
        public DbSet<Contact> Subscribes
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
