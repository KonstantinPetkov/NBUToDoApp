using Microsoft.EntityFrameworkCore;
using ToDoApp.Infrastructure.Data.Models;

namespace ToDoApp.Infrastructure.Data.Contexts
{
    /// <summary>
    /// Entity framework context for ToDoDB
    /// </summary>
    public class ToDoContext : DbContext
    {
        /// <summary>
        /// Table with ToDo items
        /// </summary>
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Database description - tables names, foreign keys etc.
        /// It can be substituted by Data anotacion attributes in models
        /// </summary>
        /// <param name="modelBuilder">Entity framework modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().ToTable("ToDoItems");
        }
    }
}
