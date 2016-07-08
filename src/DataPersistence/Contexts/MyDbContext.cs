using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPersistence.Contexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<MyContact> Contacts { get; set; }
    }
}
