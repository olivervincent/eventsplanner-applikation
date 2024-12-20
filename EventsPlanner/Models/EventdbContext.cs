﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EventsPlanner.Models;

#nullable disable

namespace EventsPlanner.EventdbContext
{
    public partial class EventdbContext : DbContext
    {
        public EventdbContext()  {  }
        public EventdbContext(DbContextOptions<EventdbContext> options) : base(options)  {  }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Stand> Stands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=mssql12.unoeuro.com;Initial Catalog=professionaleducationnetworkforinnovativesolutions_dk_db_d;User ID=professionaleducationnetwor_dk;Password=yEA9Hna25RtmGxpkfgdB;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.GuestNoNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GuestNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Guest_N__2D27B809");

                entity.HasOne(d => d.Stand)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => new { d.StandNo, d.EventNo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__2E1BDC42");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.GuestNo)
                    .HasName("PK__Guest__CB8B32A0281734E2");

                entity.Property(e => e.GuestNo).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventNo)
                    .HasName("PK__Event__AA4F173E03D4B256");

                entity.Property(e => e.EventNo).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Stand>(entity =>
            {
                entity.HasKey(e => new { e.StandNo, e.EventNo })
                    .HasName("PK__Stand__E34B708F606BBAAB");

                entity.Property(e => e.Types)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.EventNoNavigation)
                    .WithMany(p => p.Stands)
                    .HasForeignKey(d => d.EventNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stand__Event_No__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}