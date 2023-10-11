using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVVM
{
    public class TaskItem 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public override string ToString() => $"{Id} {Description}\t {Status}";//Temporary, need to remove

    }
}
