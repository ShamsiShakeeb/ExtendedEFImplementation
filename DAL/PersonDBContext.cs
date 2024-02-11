using DAL.Model;
using KhatiExtendedEF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class PersonDBContext : DatabaseContext<IEntity>
    {
        private readonly IConfiguration _configuration;
        public PersonDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public override string connectionString()
        {
            return _configuration.GetConnectionString("DevConnection");
        }

        public override void EntityBinder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student").HasKey(x => x.Id);
            modelBuilder.Entity<Teacher>().ToTable("Teacher").HasKey(x => x.Id);
            modelBuilder.Entity<CgpaHistory>().ToTable("CgpaHistory").HasNoKey();
        }
    }
}
