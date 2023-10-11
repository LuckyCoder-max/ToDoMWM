using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ToDoMVVM
{
    public class MainWindowVM : VMBase
    {
        public ObservableCollection<TaskItem> Tasks 
        { 
            get => _tasks;
            set 
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            } 
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public ICommand AddCommand => _addCommand;
        public MainWindowVM() 
        {
            _addCommand = new(Add);
            _taskManager = new TaskManager();
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }
        private RelayCommand _addCommand;
        private ObservableCollection<TaskItem> _tasks;
        private TaskManager _taskManager;
        private string _description;
        private void Add(object o)
        {
            if (string.IsNullOrWhiteSpace(Description)) return;
            TaskItem item = new() { Description = this.Description };
            _taskManager.Create(item);
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
            Description = string.Empty;
        }
    }
}
