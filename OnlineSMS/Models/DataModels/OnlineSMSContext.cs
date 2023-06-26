using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineSMS.Models.DataModels
{
    public partial class OnlineSMSContext : DbContext
    {
        public OnlineSMSContext()
        {
        }

        public OnlineSMSContext(DbContextOptions<OnlineSMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountInfo> AccountInfo { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Account__A9D10534F107B975")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Account__5C7E359ECE9896A5")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccountInfo>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Degree).HasMaxLength(255);

                entity.Property(e => e.Dislike).HasMaxLength(255);

                entity.Property(e => e.Interests).HasMaxLength(255);

                entity.Property(e => e.JobStatus).HasMaxLength(255);

                entity.Property(e => e.MaritalStatus).HasMaxLength(255);

                entity.Property(e => e.Schools).HasMaxLength(255);

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.AccountInfo)
                    .HasForeignKey(d => d.AccId)
                    .HasConstraintName("FK__AccountIn__AccId__145C0A3F");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.FriendAcc)
                    .HasForeignKey(d => d.AccId)
                    .HasConstraintName("FK__Friend__AccId__173876EA");

                entity.HasOne(d => d.AccIdFriendNavigation)
                    .WithMany(p => p.FriendAccIdFriendNavigation)
                    .HasForeignKey(d => d.AccIdFriend)
                    .HasConstraintName("FK__Friend__AccIdFri__182C9B23");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.AccId)
                    .HasConstraintName("FK__Post__AccId__1B0907CE");
            });
        }
    }
}
