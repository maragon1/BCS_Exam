using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BCS_Exam.Models
{
    public partial class BCSContext : DbContext
    {
        public BCSContext()
        {
        }

        public BCSContext(DbContextOptions<BCSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpokenToGuests> SpokenToGuests { get; set; }
        public virtual DbSet<Talktoguests> Talktoguests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configiuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configiuration.GetConnectionString("BCSDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpokenToGuests>(entity =>
            {
                entity.HasKey(e => e.ResId).HasName("PRIMARY");

                entity.ToTable("spokenToGuests");

                entity.Property(e => e.ResId)
                    .HasColumnName("ResID")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("userEmail")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Talktoguests>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("talktoguests");

                entity.Property(e => e.AreaName).HasColumnName("Area_Name");

                entity.Property(e => e.GuestMobile).HasColumnName("Guest_Mobile");

                entity.Property(e => e.GuestName).HasColumnName("Guest_Name");

                entity.Property(e => e.MemberStatus).HasColumnName("Member_Status");

                entity.Property(e => e.NightsThisRes).HasColumnName("Nights_ThisRes");

                entity.Property(e => e.ParkCode).HasColumnName("Park_Code");

                entity.Property(e => e.PmEmail).HasColumnName("PM_Email");

                entity.Property(e => e.PrevNps).HasColumnName("Prev_NPS");

                entity.Property(e => e.PrevNpsComment).HasColumnName("Prev_NPS_Comment");

                entity.Property(e => e.PrevResId).HasColumnName("Prev_ResID");

                entity.Property(e => e.PriorNights).HasColumnName("Prior_Nights");

                entity.Property(e => e.PriorRevenue).HasColumnName("Prior_Revenue");

                entity.Property(e => e.PriorVisits).HasColumnName("Prior_Visits");

                entity.Property(e => e.ResId).HasColumnName("Res_ID");

                entity.Property(e => e.RevenueThisRes).HasColumnName("Revenue_ThisRes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
