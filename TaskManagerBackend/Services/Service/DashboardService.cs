using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data.DataDbContext;
using TaskManagerBackend.Services.IServices;
using Task = TaskManagerBackend.Data.Entity.Task;
namespace TaskManagerBackend.Services.Service
{
  public class DashboardService : IDashboardService
  {
    public readonly UserDbContext context;

    public DashboardService(UserDbContext context)
    {
      this.context = context;
    }

    public Task getTaskById(int id)
    {
      try
      {
        var res = context.tasks.FromSqlRaw("SELECT * FROM Task WHERE TaskId = {0}", id).FirstOrDefault();
        return res;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return new Task();
      }
    }
    public bool addTask(Task task)
    {
      try
      {
        if (task == null)
        {
          return false;
        }
        context.tasks.Add(task);
        context.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }

    public bool removeTask(Task task)
    {
      try
      {
        context.tasks.Remove(task);
        context.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }

    public bool updateTask(Task task)
    {
      try
      {
        context.tasks.Update(task);
        context.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }

    public List<Task> getAllTask()
    {
      try
      {
        List<Task> res = context.tasks.ToList();
        return res;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return new List<Data.Entity.Task>();
      }
    }
  }
}


