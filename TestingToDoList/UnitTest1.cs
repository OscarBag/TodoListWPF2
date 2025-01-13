using TodoAppWPF;

namespace TestingToDoList
{
    public class ToDoListTest
    {

        private TodoList _todolist;
        public ToDoListTest()
        {
            _todolist = new TodoList();
        }

        [Fact]
        public void AddTask_ShouldAddTaskToList()
        {
            var task = "Test task";
            _todolist.AddTask(task);
            var tasks = _todolist.GetAllTasks();
            Assert.Contains(task, tasks);
        }

        [Fact]
        public void RemoveTask_ShouldRemoveTaskFromList()
        {
            var task = "Task to remove";
            _todolist.AddTask(task);
            _todolist.RemoveTask(0);
            var tasks = _todolist.GetAllTasks();
            Assert.DoesNotContain(task, tasks);
        }

        [Fact]
        public void RemoveTask_InvalidIndex_ShouldNotThrowException()
        {
            var task = "Vaild Task";
            _todolist.AddTask(task);
            _todolist.RemoveTask(1); //Invaild Index
            var tasks = _todolist.GetAllTasks();
            Assert.Single(tasks);
        }
    }
}