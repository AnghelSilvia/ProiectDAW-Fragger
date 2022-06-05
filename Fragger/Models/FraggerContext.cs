using Microsoft.EntityFrameworkCore;

namespace Fragger.Models
{
    public class FraggerContext : DbContext
    {
        /*
        public FraggerContext(DbSet<Perfume> perfumes, DbSet<Note> notes, string databasePath)
        {
            Perfumes = perfumes;
            Notes = notes;
            DatabasePath = databasePath;
        }
        */
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<PerfumeNote> PerfumeNotes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public string DatabasePath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={this.DatabasePath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One: Brand < - > Contact
            modelBuilder.Entity<Brand>()
                .HasOne(b => b.Contact)
                .WithOne(c => c.Brand)
                .HasForeignKey<Contact>(c => c.BrandRef);

            // One-to-Many: Brand < - > Perfume
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Perfumes)
                .WithOne(c => c.Brand);

            // Many-to-Many: Perfume < - > Note
            modelBuilder.Entity<PerfumeNote>()
                .HasKey(pn => new { pn.PerfumeId, pn.NoteId });

            modelBuilder.Entity<PerfumeNote>()
                .HasOne(pn => pn.Perfume)
                .WithMany(p => p.PerfumeNotes)
                .HasForeignKey(pn => pn.PerfumeId);
            
            modelBuilder.Entity<PerfumeNote>()
                .HasOne(pn => pn.Note)
                .WithMany(n => n.PerfumeNotes)
                .HasForeignKey(pn => pn.NoteId);

        }
    }
}
