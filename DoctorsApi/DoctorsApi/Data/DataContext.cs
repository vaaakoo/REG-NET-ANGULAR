using Microsoft.EntityFrameworkCore;
using DoctorsApi.Models;

namespace DoctorsApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Doctors> Doctors => Set<Doctors>();
    }
}
