using FormForTestWithMongo.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FormForTestWithMongo.DbContext
{
    public class FormDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; init; }
        public static FormDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<FormDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public FormDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToCollection("Users");
        }
    }
}
