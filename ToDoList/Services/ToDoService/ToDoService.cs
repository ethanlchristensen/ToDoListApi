using ToDoList.Models;

namespace ToDoList.Services.ToDoService
{
    public class ToDoService : IToDoService
    {

        private readonly DataContext _context;

        public ToDoService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> AddToDoItem(ToDoItem item)
        {
            await _context.ToDoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<List<ToDoItem>?> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem is null)
                return null;

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem?> GetToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem != null)
                return toDoItem;
            return null;
        }

        public async Task<List<ToDoItem>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<List<ToDoItem>?> UpdateToDoItem(int id, ToDoItem item)
        {

            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem is null)
                return null;

            toDoItem.Title = item.Title;
            toDoItem.Description = item.Description;
            toDoItem.IsCompleted = item.IsCompleted;
            await _context.SaveChangesAsync();

            return await _context.ToDoItems.ToListAsync();
        }
    }
}
