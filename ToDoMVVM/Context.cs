using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVVM
{
    public class Context : DbContext
    {
        private readonly StreamWriter logWriter = new("logs.txt", true);

        public DbSet<TaskItem> Tasks { get; set; }
        public Context() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasks.db");
            optionsBuilder.LogTo(logWriter.WriteLine, LogLevel.Information);
        }
        public override void Dispose()
        {
            base.Dispose();
            logWriter.Dispose();
        }
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logWriter.DisposeAsync();
        }
    }
}
