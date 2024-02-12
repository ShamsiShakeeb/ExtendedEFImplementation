using DAL.Model;
using KhatiExtendedEF.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class PersonDBContext : DatabaseContextIdentityUser<IEntity,IdentityUser>
    {
        private readonly IConfiguration _configuration;
        public PersonDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override string connectionString()
        {
            return _configuration.GetConnectionString("DevConnection");
        }

        public override void EntityBinder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CgpaHistory>().ToTable("CgpaHistory").HasNoKey();
        }
    }
}
