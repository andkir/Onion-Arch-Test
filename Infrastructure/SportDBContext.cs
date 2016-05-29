using System.Data.Entity;
using Core;

namespace Infrastructure
{
    public partial class SportDBContext : DbContext
    {
        public SportDBContext()
            : base("name=SportDBContext")
        {
        }

        public virtual DbSet<SportComplex> SportComplex { get; set; }
        public virtual DbSet<SportType> SportType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportComplex>()
                .HasMany(e => e.SportType)
                .WithRequired(e => e.SportComplex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.SportComplex)
                .WithRequired(e => e.User);
        }
    }
}
