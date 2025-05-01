using Microsoft.EntityFrameworkCore;
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
        public DbSet<Document> Documents { get; set; }
        public DbSet<Signature> Signatures { get; set; }

        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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