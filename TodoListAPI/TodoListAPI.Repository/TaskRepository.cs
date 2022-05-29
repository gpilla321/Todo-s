using TodoListAPI.Core.Domain;
using TodoListAPI.Repository.Interface;

namespace TodoListAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository()
        {

        }
        public async  Task<bool> Delete(int id)
        {
            return true;
        }

        public async Task<TaskItem> Get(int id) => new TaskItem(id);

        public async Task<IList<TaskItem>> GetAll() => new List<TaskItem>();

        public async Task<TaskItem> Insert(TaskItem item) => item;

        public async Task<TaskItem> Update(TaskItem item) => item;
    }
}
