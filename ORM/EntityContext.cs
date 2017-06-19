using System.Data.Entity;
using ORM.Configuration;
using Entity;



namespace ORM
{
    public class EntityContext : DbContext
    {

        public EntityContext() : base("AudioCardFile")
        {
        }
        public EntityContext(string connectionString):base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<AudioRating> AudioRatings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

        }
    }
}
