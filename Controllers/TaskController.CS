using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskProgress.Models;

namespace EmployeeTaskProgress.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // DISPLAY TASK LIST WITH RELATED PROJECT AND CLIENT
        public IActionResult Index()
        {
            var list = _context.TaskItems
                .Include(t => t.Project)
                .ThenInclude(p => p.Client)
                .ToList();

            return View(list);
        }

        // LOAD CREATE TASK VIEW WITH OPTIONAL DEFAULT VALUES
        [HttpGet]
        public IActionResult Create(string taskDate, int? startHour, int? endHour)
        {
            ViewBag.Projects = new SelectList(_context.Projects, "Id", "ProjectName");

            // Set default values for form fields
            ViewBag.PassedDate = taskDate ?? DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.PassedStart = startHour ?? 9;
            ViewBag.PassedEnd = endHour ?? (startHour.HasValue ? startHour + 1 : 10);

            return View();
        }

        // HANDLE CREATE TASK REQUEST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DateTime TaskDate, int StartHour, int EndHour, TaskItem task)
        {
            // Assign start and end datetime based on selected date and hours
            task.TaskDateTime = TaskDate.AddHours(StartHour);
            task.EndDateTime = TaskDate.AddHours(EndHour);

            // Retrieve current logged-in user from session and assign task
            var username = HttpContext.Session.GetString("User");
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == username);

            if (currentUser != null)
            {
                task.UserId = currentUser.Id;
            }

            // Handle overnight tasks (end time is next day)
            if (EndHour <= StartHour)
            {
                task.EndDateTime = task.EndDateTime.AddDays(1);
            }

            _context.TaskItems.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index");

            ViewBag.Projects = new SelectList(_context.Projects, "Id", "ProjectName", task.ProjectId);
            return View(task);
        }

        // LOAD EDIT TASK VIEW
        public IActionResult Edit(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null) return NotFound();

            ViewBag.Projects = new SelectList(_context.Projects, "Id", "ProjectName", task.ProjectId);
            return View(task);
        }

        // HANDLE EDIT TASK REQUEST
        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            _context.TaskItems.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index");

            ViewBag.Projects = new SelectList(_context.Projects, "Id", "ProjectName", task.ProjectId);
            return View(task);
        }

        // DELETE TASK
        public IActionResult Delete(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // DISPLAY TASKS IN CALENDAR VIEW
        public IActionResult Calendar()
        {
            var tasks = _context.TaskItems
                .Include(t => t.Project)
                .ToList();

            return View(tasks);
        }
    }
}