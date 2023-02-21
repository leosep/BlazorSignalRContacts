using Microsoft.EntityFrameworkCore;

namespace BlazorContacts.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
