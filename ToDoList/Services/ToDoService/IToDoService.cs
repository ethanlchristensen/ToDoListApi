using ToDoList.Models;

namespace ToDoList.Services.ToDoService
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetToDoItems();
        Task<ToDoItem?> GetToDoItem(int id);
        Task<List<ToDoItem>> AddToDoItem(ToDoItem item);
        Task<List<ToDoItem>?> UpdateToDoItem(int id, ToDoItem item);
        Task<List<ToDoItem>?> DeleteToDoItem(int id);
    }
}
