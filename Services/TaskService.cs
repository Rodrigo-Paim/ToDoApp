using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        IEnumerable<Models.Task> GetAll();
        Models.Task Add(Models.Task task);
        bool Update(int id, string title, string description);
        bool Remove(int id);
    }

    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Task> GetAll() => _context.Tasks.ToList();

        public Models.Task Add(Models.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public bool Update(int id, string title, string description)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            task.Title = title;
            task.Description = description;
            _context.SaveChanges();
            return true;
        }

        public bool Remove(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}
