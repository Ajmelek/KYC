using Microsoft.EntityFrameworkCore;
using STB_everywhere.Migrations;
using STB_everywhere.Models;

namespace STB_everywhere.Data
{
    public class KycDbContext : DbContext
    {
        public KycDbContext(DbContextOptions<KycDbContext> options) : base(options)
        {
        }

        public DbSet<KycApplication> KycApplications { get; set; }
        public DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressProof> AddressProofs { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DemandeModificationClient> DemandeModificationClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Admin table
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Login).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Login).IsUnique();
            });

            // Configure SuperAdmin table
            modelBuilder.Entity<SuperAdmin>(entity =>
            {
                entity.ToTable("SuperAdmin");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Login).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Login).IsUnique();
            });

            // Configure DemandeModificationClient table
            modelBuilder.Entity<DemandeModificationClient>(entity =>
            {
                entity.ToTable("DemandeModificationClient");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.clientID).IsRequired().HasMaxLength(50);
                entity.Property(e => e.password).IsRequired().HasMaxLength(255);
                entity.HasOne(e => e.Client)
                    .WithMany()
                    .HasForeignKey(e => e.clientID)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Reclamation>()
        .HasOne(r => r.Client)
        .WithMany(c => c.Reclamations)
        .HasForeignKey(r => r.ClientId)
        .HasConstraintName("FK_Reclamation_Client_ClientId");

            // Configure relationships with explicit delete behavior
            modelBuilder.Entity<KycApplication>()
        .HasOne(k => k.ApplicantDetails)
        .WithOne(ad => ad.KycApplication)
        .HasForeignKey<ApplicantDetail>(ad => ad.KycApplicationId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<KycApplication>()
                .HasMany(k => k.Addresses)
                .WithOne(a => a.KycApplication)
                .HasForeignKey(a => a.KycApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KycApplication>()
                .HasMany(k => k.AddressProofs)
                .WithOne(ap => ap.KycApplication)
                .HasForeignKey(ap => ap.KycApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KycApplication>()
                .HasMany(k => k.Documents)
                .WithOne(d => d.KycApplication)
                .HasForeignKey(d => d.KycApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KycApplication>()
                .HasOne(k => k.Signature)
                .WithOne(s => s.KycApplication)
                .HasForeignKey<Signature>(s => s.KycApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure indexes
            modelBuilder.Entity<ApplicantDetail>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<KycApplication>()
                .HasIndex(k => k.Status);

            // Configure AddressProof
            modelBuilder.Entity<AddressProof>()
                .Property(ap => ap.ProofType)
                .HasMaxLength(100);

            // Configure Document
            modelBuilder.Entity<Document>()
                .Property(d => d.FileName)
                .HasMaxLength(255);

            modelBuilder.Entity<Document>()
                .Property(d => d.FilePath)
                .HasMaxLength(500);
        }
    }
}