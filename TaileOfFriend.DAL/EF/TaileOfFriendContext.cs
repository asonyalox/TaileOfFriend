using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TaileOfFriend.DAL.Enteties
{
    public class TaileOfFriendContext: IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() {Name="Admin", NormalizedName="Admin".ToUpper() },
                new IdentityRole() { Name = "User", NormalizedName = "User".ToUpper() }
                );

            modelBuilder.Entity<ProfileCategory>()
                .HasKey(t => new { t.CategoryId, t.ProfileId });

             modelBuilder.Entity<ProfileCategory>()
                .HasOne(pt => pt.ProfileId)
                .WithMany(p => p.ProfileCategories)
                .HasForeignKey(pt => pt.ProfileId);

            modelBuilder.Entity<ProfileCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.ProfileCategories)
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
            Database.Migrate();
        }
    }
}
