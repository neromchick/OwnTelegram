using Microsoft.EntityFrameworkCore;

namespace ChatServer
{
    public class ChatDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Message> Messages => Set<Message>();

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
    }
}
