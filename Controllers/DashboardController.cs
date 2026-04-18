using EmployeeTaskProgress.Models;
using EmployeeTaskProgress.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskProgress.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        // Load dashboard data
        public async Task<IActionResult> Index()
        {
            var clientsCount = await _context.Clients.CountAsync();
            var projectsCount = await _context.Projects.CountAsync();
            var tasksCount = await _context.TaskItems.CountAsync();

            var recentTasks = await _context.TaskItems
                .Include(t => t.Project)
                .ThenInclude(p => p.Client)
                .OrderByDescending(t => t.TaskDateTime)
                .Take(3)
                .ToListAsync();

            var recentProjects = await _context.Projects
                .Include(p => p.Client)
                .OrderByDescending(p => p.Id)
                .Take(3)
                .ToListAsync();

            var model = new DashboardViewModel
            {
                ClientsCount = clientsCount,
                ProjectsCount = projectsCount,
                TasksCount = tasksCount,
                RecentTasks = recentTasks,
                RecentProjects = recentProjects
            };

            return View(model);
        }
    }
}