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

        //public void UpdateTask(TaskItem)
        //{
        //    Task existingTask = tasks.FirstOrDefault(t => t.Id == taskId);
        //    if (existingTask != null)
        //    {
        //        existingTask.Title = updatedTask.Title;
        //        existingTask.Status = updatedTask.Status;
        //    }
        //}

        //public bool DeleteTask(TaskItem)
        //{
        //    Task taskToRemove = tasks.FirstOrDefault(t => t.Id == taskId);
        //    if (taskToRemove != null)
        //    {
        //        tasks.Remove(taskToRemove);
        //    }
        //}
    }
}

