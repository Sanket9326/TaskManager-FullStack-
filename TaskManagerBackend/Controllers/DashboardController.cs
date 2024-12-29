using Microsoft.AspNetCore.Mvc;
using Task = TaskManagerBackend.Data.Entity.Task;
using TaskManagerBackend.Services.IServices;

namespace TaskManagerBackend.Controllers
{
  [Route("api/task")]
  [ApiController]
  public class DashboardController : Controller
  {
    public IDashboardService dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
      this.dashboardService = dashboardService;
    }

    [HttpGet]
    public IActionResult getAllTasks()
    {
      List<Task> allTasks = dashboardService.getAllTask();
      return Ok(allTasks);
    }

    [HttpPost("add")]
    public IActionResult addTask([FromBody] Task task)
    {
      var response = dashboardService.addTask(task);
      if (response == false)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }

    [HttpPost("delete")]
    public IActionResult deleteTask([FromBody] Task task)
    {
      var res = dashboardService.removeTask(task);
      if (res == false)
      {
        return BadRequest(res);
      }
      return Ok(res);
    }

    [HttpPost("update")]
    public IActionResult updateTAsk([FromBody] Task task)
    {
      var res = dashboardService.updateTask(task);
      if (res == false)
      {
        return BadRequest(res);
      }
      return Ok(res);
    }

  }
}
