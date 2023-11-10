using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.ToDoService;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoListController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Hello()
        {
            return Ok("Hello World!");
        }

        [HttpGet]
        [Route("/getTodos")]
        public async Task<ActionResult<List<ToDoItem>>> GetToDos()
        {
            var result = await _toDoService.GetToDoItems();
            return Ok(result);
        }

        [HttpGet]
        [Route("/getToDo/{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDo(int id)
        {
            var result = await _toDoService.GetToDoItem(id);
            if (result != null)
                return Ok(result);
            return NotFound("Unable to find corresponding To Do Item!");
        }

        [HttpPost]
        [Route("/addToDo")]
        public async Task<ActionResult<List<ToDoItem>>> AddToDo(ToDoItem toDo)
        {
            var result = await _toDoService.AddToDoItem(toDo);
            return Ok(result);
        }

        [HttpPut]
        [Route("/updateToDo/{id}")]
        public async Task<ActionResult<List<ToDoItem>>> UpdateToDo(int id, ToDoItem request)
        {
            var result = await _toDoService.UpdateToDoItem(id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/removeToDo/{id}")]
        public async Task<ActionResult<List<ToDoItem>>> DeleteToDo(int id)
        {
            var result = await _toDoService.DeleteToDoItem(id);
            if (result != null)
                return Ok(result);
            return NotFound("Unable to find corresponding To Do Item to delete!");
        }
    }
}
