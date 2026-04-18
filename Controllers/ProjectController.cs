using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskProgress.Models;

namespace EmployeeTaskProgress.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // Get all projects
        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .ToList();

            return View(projects);
        }

        // Show create form
        public IActionResult Create()
        {
            ViewBag.Clients = new SelectList(_context.Clients, "Id", "ClientName");
            return View();
        }

        // Create project (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
                return NotFound();

            ViewBag.ClientId = new SelectList(_context.Clients, "Id", "ClientName", project.ClientId);
            return View(project);
        }

        // Update project (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Delete project
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Find(id);

            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}