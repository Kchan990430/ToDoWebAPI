using ToDoWebAPI.BusinessEntity;
using ToDoWebAPI.DataAccess;

namespace ToDoWebAPI.BusinessClass
{
    public interface IToDoBC
    {
        Task<IEnumerable<ToDoItem>> GetTodos();
        Task<ToDoItem> GetTodoById(int id);
        Task AddTodo(ToDoItem todo);
        Task UpdateTodo(ToDoItem todo);
        Task DeleteTodo(int id);
        Task<IEnumerable<ToDoItem>> FilterTodosByStatus(string status);
        Task<IEnumerable<ToDoItem>> SortTodos(string sortBy);
        Task<ToDoItem?> FindToDo(ToDoItem todo);
    }

    public class ToDoBC : IToDoBC
    {
        private readonly IToDoDA _toDoDA;

        public ToDoBC(IToDoDA todoDA)
        {
            _toDoDA = todoDA;
        }

        public async Task<IEnumerable<ToDoItem>> GetTodos()
        {
            return await _toDoDA.GetTodos();
        }

        public async Task<ToDoItem> GetTodoById(int id)
        {
            return await _toDoDA.GetTodoById(id);
        }

        public async Task AddTodo(ToDoItem todo)
        {
            await _toDoDA.AddTodo(todo);
        }

        public async Task UpdateTodo(ToDoItem todo)
        {
            await _toDoDA.UpdateTodo(todo);
        }

        public async Task DeleteTodo(int id)
        {
            await _toDoDA.DeleteTodo(id);
        }

        public async Task<IEnumerable<ToDoItem>> FilterTodosByStatus(string status)
        {
            return await _toDoDA.FilterTodosByStatus(status);
        }

        public async Task<IEnumerable<ToDoItem>> SortTodos(string sortBy)
        {
            return await _toDoDA.SortTodos(sortBy);
        }

        public async Task<ToDoItem?> FindToDo(ToDoItem todo)
        {
            var response = await _toDoDA.FindToDo(todo);
            return response;
        }
    }
}
