using TodoListAPI.Core.Domain;
using TodoListAPI.Repository.Interface;
using TodoListAPI.Resources;
using TodoListAPI.Service.Interface;

namespace TodoListAPI.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService()
        {

        }

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<bool> Delete(int id)
        {
            TaskItem storedItem = await taskRepository.Get(id);

            if (storedItem == null)
                throw new Exception(ErrorMessage_TaskItem._007_NotFound);

            return await taskRepository.Delete(storedItem.Id);
        }

        public async Task<TaskItem> Insert(TaskItem item)
        {
            if (item.InsertIsValid() is false)
                throw new Exception(item.GetErrorsConcat());

            return await taskRepository.Insert(item);
        }

        public async Task<TaskItem> Update(TaskItem item)
        {
            if (item.UpdateIsValid() is false)
                throw new Exception(item.GetErrorsConcat());

            return await taskRepository.Update(item);
        }

        public async Task<TaskItem> Get(int id) => await taskRepository.Get(id);

        public async Task<IList<TaskItem>> GetAll() => await taskRepository.GetAll();
    }
}