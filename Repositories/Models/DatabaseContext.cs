using System.Data.Entity;
using Repositories.Models.Entities;

namespace Repositories.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
    }
}