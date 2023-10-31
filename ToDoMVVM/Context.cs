using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVVM
{
    public class Context : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public Context() => Database.EnsureCreated();
        //public Context() => Database.EnsureDeleted();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }
    }
}
