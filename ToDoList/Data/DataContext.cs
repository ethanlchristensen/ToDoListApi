using ToDoList.Models;

namespace ToDoList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=tododb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
