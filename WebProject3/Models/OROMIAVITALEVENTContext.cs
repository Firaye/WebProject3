using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebProject3.Models
{
    public partial class OROMIAVITALEVENTContext : DbContext
    {
        public OROMIAVITALEVENTContext()
        {
        }

        public OROMIAVITALEVENTContext(DbContextOptions<OROMIAVITALEVENTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adoptiontbl> Adoptiontbl { get; set; }
        public virtual DbSet<Birthtbl> Birthtbl { get; set; }
        public virtual DbSet<Custometbl> Custometbl { get; set; }
        public virtual DbSet<Deathtbl> Deathtbl { get; set; }
        public virtual DbSet<Divorcetbl> Divorcetbl { get; set; }
        public virtual DbSet<Marriagetbl> Marriagetbl { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4KPJHBK;Database=OROMIAVITALEVENT;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoptiontbl>(entity =>
            {
                entity.HasKey(e => e.AdoptId);

                entity.Property(e => e.AdoptId).HasColumnName("AdoptID");

                entity.Property(e => e.AdoptFullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ChildFullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CitizenshipofAdopter).HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.ReasonforAdoption)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sexofchild)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Adoptiontbl)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Adoptiontbl__Cid__33D4B598");
            });

            modelBuilder.Entity<Birthtbl>(entity =>
            {
                entity.HasKey(e => e.Cnum);

                entity.ToTable("birthtbl");

                entity.HasIndex(e => e.Cid)
                    .HasName("UQ__birthtbl__C1FFD860FF5CCC24")
                    .IsUnique();

                entity.Property(e => e.Cnum).HasColumnName("cnum");

                entity.Property(e => e.DateofIssue).HasColumnType("date");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Mfullname)
                    .IsRequired()
                    .HasColumnName("MFullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasMaxLength(10);

                entity.Property(e => e.Woreda)
                    .IsRequired()
                    .HasColumnName("woreda")
                    .HasMaxLength(50);

                entity.HasOne(d => d.C)
                    .WithOne(p => p.Birthtbl)
                    .HasForeignKey<Birthtbl>(d => d.Cid)
                    .HasConstraintName("FK__birthtbl__Cid__37A5467C");
            });

            modelBuilder.Entity<Custometbl>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("custometbl");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(50);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    //.IsRequired()
                    .HasColumnName("Country")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Deathtbl>(entity =>
            {
                entity.HasKey(e => e.DrefNum);

                entity.HasIndex(e => e.Cid)
                    .HasName("UQ__Deathtbl__C1FFD860D016BE1A")
                    .IsUnique();

                entity.Property(e => e.DrefNum).HasColumnName("DRefNum");

                entity.Property(e => e.CaseofDeath)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateofDeath).HasColumnType("date");

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Reltionofwittness)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Wittness)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Woreda)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.C)
                    .WithOne(p => p.Deathtbl)
                    .HasForeignKey<Deathtbl>(d => d.Cid)
                    .HasConstraintName("FK__Deathtbl__Cid__34C8D9D1");
            });

            modelBuilder.Entity<Divorcetbl>(entity =>
            {
                entity.HasKey(e => e.Did);

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.DateofDivorce).HasColumnType("date");

                entity.Property(e => e.HusbandFullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.RequesterofDinvorce).HasMaxLength(100);

                entity.Property(e => e.WifeFullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Divorcetbl)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Divorcetbl__Cid__36B12243");
            });

            modelBuilder.Entity<Marriagetbl>(entity =>
            {
                entity.HasKey(e => e.Mnum);

                entity.Property(e => e.Mnum).HasColumnName("MNUM");

                entity.Property(e => e.DateofMarriage).HasColumnType("date");

                entity.Property(e => e.HusbandFullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Wifefullname)
                    .HasColumnName("wifefullname")
                    .HasMaxLength(100);

                entity.Property(e => e.Wittness1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Wittness2).HasMaxLength(50);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasColumnName("zone")
                    .HasMaxLength(50);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Marriagetbl)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Marriagetbl__Cid__4E88ABD4");
            });
        }
    }
}
