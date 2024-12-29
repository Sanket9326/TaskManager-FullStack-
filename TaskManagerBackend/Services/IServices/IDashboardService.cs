using Task = TaskManagerBackend.Data.Entity.Task;

namespace TaskManagerBackend.Services.IServices
{
  public interface IDashboardService
  {
    public bool addTask(Task task);
    public bool removeTask(Task task);
    public Task getTaskById(int id);
    public bool updateTask(Task task);
    public List<Task> getAllTask();
  }
}
