using Microsoft.EntityFrameworkCore;

namespace TicketSystem.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<T_Parameter> T_Parameters { get; set; } = null!;
        public virtual DbSet<T_Permission> T_Permissions { get; set; } = null!;
        public virtual DbSet<T_Role> T_Roles { get; set; } = null!;
        public virtual DbSet<T_Ticket> T_Tickets { get; set; } = null!;
        public virtual DbSet<T_User> T_Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TicketSystem;User ID=sa;Password=`1qa~!QA;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Parameter>(entity =>
            {
                entity.ToTable("T_Parameter");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<T_Permission>(entity =>
            {
                entity.ToTable("T_Permission");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<T_Role>(entity =>
            {
                entity.ToTable("T_Role");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "T_Role_Permission",
                        l => l.HasOne<T_Permission>().WithMany().HasForeignKey("Permission").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_Role_Permission_T_Permission"),
                        r => r.HasOne<T_Role>().WithMany().HasForeignKey("RoleID").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_Role_Permission_T_Role"),
                        j =>
                        {
                            j.HasKey("RoleID", "Permission");

                            j.ToTable("T_Role_Permission");
                        });
            });

            modelBuilder.Entity<T_Ticket>(entity =>
            {
                entity.ToTable("T_Ticket");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Priority).HasMaxLength(50);

                entity.Property(e => e.Severity)
                    .HasMaxLength(50)
                    .HasComment("");

                entity.Property(e => e.Summary).HasMaxLength(500);
            });

            modelBuilder.Entity<T_User>(entity =>
            {
                entity.ToTable("T_User");

                entity.Property(e => e.Account)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "T_User_Role",
                        l => l.HasOne<T_Role>().WithMany().HasForeignKey("RoleID").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_User_Role_T_Role"),
                        r => r.HasOne<T_User>().WithMany().HasForeignKey("UserID").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_T_User_Role_T_User"),
                        j =>
                        {
                            j.HasKey("UserID", "RoleID");

                            j.ToTable("T_User_Role");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}