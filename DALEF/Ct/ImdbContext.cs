using DALEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DALEF.Ct
{
    public class ImdbContext : R2024Context
    {
        private readonly string _connectionString;
        private DbContextOptions<ImdbContext> dbContextOptions;

        public ImdbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ImdbContext(DbContextOptions<ImdbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            });
        }
    }
}
