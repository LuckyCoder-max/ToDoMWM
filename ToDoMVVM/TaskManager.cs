using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVVM
{
    public class TaskManager
    {
        public void Create(TaskItem task)
        {
            using(var context = new Context())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }
        public List<TaskItem> GetTasks()
        {
            using( var context = new Context())
            {
                return context.Tasks.ToList();
            }
        }
        public void Update(TaskItem task)
        {
            using (var context = new Context())
            {
                var existingTask = context.Tasks.Find(task?.Id);
                if (existingTask is null) return;
                existingTask.Status = !existingTask.Status;
                context.SaveChanges();
            }
        }
        public void Delete(TaskItem task)
        {
            using (var context = new Context())
            {
                if (task != null)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
        }
        public void ClearAll()
        {
            using (var context = new Context())
            {
                context.Database.EnsureDeleted();
            }
        }
        public void ChangeDescription(TaskItem task, string description)
        {
            using (var context = new Context())
            {
                var existingTask = context.Tasks.Find(task?.Id);
                if (existingTask is null) return;
                existingTask.Description = description; 
                context.SaveChanges();
            }
        }
    }
}

