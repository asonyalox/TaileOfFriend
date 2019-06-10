using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaileOfFriend.DAL.Enteties
{
    public class TaileOfFriendContext: IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Userse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCategory>()
                .HasKey(t => new { t.CategoryId, t.UserId });

            modelBuilder.Entity<UserCategory>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserCategories)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.UserCategories)
                .HasForeignKey(pt => pt.CategoryId);

            modelBuilder.Entity<EventCategory>()
                .HasKey(t => new { t.EventId, t.CategoryId });

            modelBuilder.Entity<EventCategory>()
            .HasOne(pt => pt.Event)
            .WithMany(p => p.EventCategories)
            .HasForeignKey(pt => pt.EventId);

            modelBuilder.Entity<EventCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.EventCategories)
                .HasForeignKey(pt => pt.CategoryId);



        }

        public TaileOfFriendContext(DbContextOptions<TaileOfFriendContext> options)
            : base(options)
        {

        }
    }
}
