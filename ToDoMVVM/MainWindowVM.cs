using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public TaskItem SelectedItem
        {
            get 
            {
                Description = _selectedItem?.Description;
                return _selectedItem;
            } 
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ICommand AddCommand => _addCommand;
        public ICommand DeleteCommand => _deleteCommand;
        public ICommand UpdateCommand => _updateCommand;
        public ICommand ClearCommand => _clearCommand;
        public ICommand ChangeCommand => _changeCommand;
        public MainWindowVM() 
        {
            _addCommand = new(Add);
            _deleteCommand = new(Delete);
            _updateCommand = new(Update);
            _clearCommand = new(ClearAll);
            _changeCommand = new (Change);
            _taskManager = new TaskManager();
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }
        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _clearCommand;
        private RelayCommand _changeCommand;
        private ObservableCollection<TaskItem> _tasks;
        private TaskManager _taskManager;
        private string _description;
        private TaskItem _selectedItem;
        private void Add(object o)
        {
            if (string.IsNullOrWhiteSpace(Description)) return;
            TaskItem item = new() { Description = RemoveExtraSpaces(this.Description), Date = DateTime.Today};
            _taskManager.Create(item);
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
            Description = string.Empty;
        }
        private void Delete(object o)
        {
            _taskManager.Delete(SelectedItem);
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }

        private void Update(object o)
        {
            _taskManager?.Update(SelectedItem);
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }
        private void ClearAll(object o)
        { 
            _taskManager.ClearAll();
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }
        private void Change(object o)
        {
            if (string.IsNullOrWhiteSpace(Description)) return;
            _taskManager.ChangeDescription(_selectedItem, RemoveExtraSpaces(Description));
            Description = string.Empty;
            Tasks = new ObservableCollection<TaskItem>(_taskManager.GetTasks());
        }

        private string RemoveExtraSpaces(string input)
        {
            return Regex.Replace(input, @"\s+", " ");
        }
    }
}
