using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Table
{
    public partial class SEContext : DbContext
    {
        public SEContext()
            : base("name=SEContext")
        {
        }

        public virtual DbSet<Ages> Ages { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventsOrganizers> EventsOrganizers { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ages>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Ages)
                .HasForeignKey(e => e.AgeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Place)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventsOrganizers)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventsOrganizers>()
                .HasMany(e => e.Session)
                .WithRequired(e => e.EventsOrganizers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Organizer>()
                .HasMany(e => e.EventsOrganizers)
                .WithRequired(e => e.Organizer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Organizer)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .HasMany(e => e.User)
                .WithMany(e => e.Session)
                .Map(m => m.ToTable("UsersSessions").MapLeftKey("SessionId").MapRightKey("UserId"));

            modelBuilder.Entity<Type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
