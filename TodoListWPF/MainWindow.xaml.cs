using System.Windows;
using TodoListWPF;

namespace TodoAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoList _todolist;

        public MainWindow()
        {
            InitializeComponent();
            _todolist = new TodoList();
        }

        /// <summary>
        /// Lägger till en todo-item i listan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            string task = TaskTextBox.Text;

            if (!string.IsNullOrEmpty(task))
            {
                _todolist.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }
        }

        /// <summary>
        /// Uppdaterar listan i Todolist
        /// </summary>
        private void UpdateTaskList()
        {
            TasksListBox.Items.Clear();
            foreach (var task in _todolist.GetAllTasks())
            {
                TasksListBox.Items.Add(task);
            }
        }

        /// <summary>
        /// Tar bort item i listan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedIndex >= 0)
            {
                _todolist.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();
            }
        }
    }
}
