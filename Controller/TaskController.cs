using Lab5.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController
    {
        public TaskManager TaskManager { get; set; }
        public TaskController() 
        {
            TaskManager taskManager = new TaskManager();
            this.TaskManager = taskManager;
        }
        /// <summary>
        /// Tworzenie nowego zadania
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void CreateTask(Lab5.Tasks.Task zadanie)
        {
            TaskManager.AddTask(zadanie);
            //_context.Tasks.Add(zadanie);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetTask", new { id = zadanie.Id }, zadanie);
        }

        /// <summary>
        /// Pobieranie wszystkich zadań
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Lab5.Tasks.Task> GetAllTasks()
        {
            return TaskManager.GetTasks();
        }

        /// <summary>
        /// Pobieranie taska po ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Lab5.Tasks.Task GetTask(int id)
        {
            return TaskManager.GetTaskById(id);
        }

        /// <summary>
        /// Aktualizacja danych danego zadania
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zadanie"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTask(int id, Lab5.Tasks.Task zadanie)
        //{
        //    if (id != zadanie.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(zadanie).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TaskExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// Usuwanie zadania
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
            bool istnieje = TaskExists(id);
            if (istnieje)
            {
              TaskManager.DeleteTask(id);
            }
        }      

        // funkcja pomocnicza
        private bool TaskExists(int id)
        {
            return TaskManager.GetTasks().Any(e => e.Id == id);
        }
    }
}
