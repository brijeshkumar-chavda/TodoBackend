using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        public static List<Todo> todoList = new List<Todo>();

        [HttpGet(Name = "GetTodo")]
        public IActionResult GetTodo()
        {
            if (todoList.Count > 0)
                return Ok(todoList);

            Todo todo1 = new Todo();
            todo1.Id = 1;
            todo1.Title = "Learn C#";
            todo1.IsCompleted = false;
            todoList.Add(todo1);

            Todo todo2 = new Todo();
            todo2.Id = 2;
            todo2.Title = "Learn ASP.NET Core";
            todo2.IsCompleted = false;
            todoList.Add(todo2);

            Todo todo3 = new Todo();
            todo3.Id = 3;
            todo3.Title = "Build a Todo App";
            todo3.IsCompleted = false;
            todoList.Add(todo3);

            return Ok(todoList);
        }

        [HttpGet("{id}", Name = "GetTodoById")]
        public IActionResult GetTodoById(int id)
        {
            var singleTask = todoList.FirstOrDefault(singleTask => singleTask.Id == id);

            return Ok(singleTask);
        }

        [HttpPost(Name = "CreateTask")]
        public IActionResult CreateTask(Todo singleTask)
        {
            todoList.Add(singleTask);
            return Ok(todoList);
        }

        [HttpDelete(Name = "DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            var singleTask = todoList.FirstOrDefault(singleTask => singleTask.Id == id);

            if (singleTask != null)
                todoList.Remove(singleTask);
            return Ok(todoList);
        }

        [HttpPut("{id}", Name = "UpdateTask")]
        public IActionResult UpdateTask(int id, Todo updatedTask)
        {
            var singleTask = todoList.FirstOrDefault(singleTask => singleTask.Id == id);

            if (singleTask != null)
            {
                singleTask.Title = updatedTask.Title;
                singleTask.IsCompleted = updatedTask.IsCompleted;
            }
            return Ok(todoList);
        }
    }
}