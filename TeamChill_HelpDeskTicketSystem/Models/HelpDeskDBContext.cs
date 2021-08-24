using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TeamChill_HelpDeskTicketSystem.Models
{
    public partial class HelpDeskDBContext : DbContext
    {
        public HelpDeskDBContext()
        {
        }

        public HelpDeskDBContext(DbContextOptions<HelpDeskDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Hdcomment> Hdcomments { get; set; }
        public virtual DbSet<Hdticket> Hdtickets { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=HelpDeskDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.Property(e => e.BookmarkId).HasColumnName("BookmarkID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(63);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookmarks__Ticke__2D27B809");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.UserEmail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookmarks__UserE__2E1BDC42");
            });

            modelBuilder.Entity<Hdcomment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__HDCommen__C3B4DFAA443D9B74");

                entity.ToTable("HDComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentDateTime).HasColumnType("datetime");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.UserEmail).HasMaxLength(63);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Hdcomments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HDComment__Ticke__2A4B4B5E");

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Hdcomments)
                    .HasForeignKey(d => d.UserEmail)
                    .HasConstraintName("FK__HDComment__UserE__29572725");
            });

            modelBuilder.Entity<Hdticket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__HDTicket__712CC6274D97C565");

                entity.ToTable("HDTicket");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Department).HasMaxLength(31);

                entity.Property(e => e.OpenDateTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(63);

                entity.Property(e => e.Type).HasMaxLength(31);

                entity.Property(e => e.UserEmail).HasMaxLength(63);

                entity.HasOne(d => d.UserEmailNavigation)
                    .WithMany(p => p.Hdtickets)
                    .HasForeignKey(d => d.UserEmail)
                    .HasConstraintName("FK__HDTicket__UserEm__267ABA7A");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserEmail)
                    .HasName("PK__UserTabl__08638DF9CDDE8659");

                entity.ToTable("UserTable");

                entity.Property(e => e.UserEmail).HasMaxLength(63);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
