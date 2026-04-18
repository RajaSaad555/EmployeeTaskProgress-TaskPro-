using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskProgress.Models;
using System.Linq;
using static EmployeeTaskProgress.ViewModels.ReportViewModel;
using EmployeeTaskProgress.ViewModels;

namespace EmployeeTaskProgress.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        // LOAD REPORTS VIEW WITH FILTERED DATA
        [HttpGet]
        public IActionResult Reports(ReportViewModel vm)
        {
            ViewBag.Users = _context.Users.AsNoTracking().ToList();
            ViewBag.Projects = _context.Projects.AsNoTracking().ToList();

            IQueryable<TaskItem> query = _context.TaskItems.AsNoTracking();

            // FILTER BY USERS
            if (vm.SelectedUserIds?.Any() == true)
                query = query.Where(t => t.UserId.HasValue &&
                                         vm.SelectedUserIds.Contains(t.UserId.Value));

            // FILTER BY PROJECTS
            if (vm.SelectedProjectIds?.Any() == true)
                query = query.Where(t => vm.SelectedProjectIds.Contains(t.ProjectId));

            // DATE RANGE FILTERS
            if (vm.DateRange == "this_week")
            {
                var start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                query = query.Where(t => t.TaskDateTime >= start);
            }
            else if (vm.DateRange == "this_month")
            {
                var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                query = query.Where(t => t.TaskDateTime >= start);
            }
            else if (vm.DateRange == "custom" && vm.FromDate.HasValue && vm.ToDate.HasValue)
            {
                var from = vm.FromDate.Value.Date;
                var to = vm.ToDate.Value.Date.AddDays(1);

                query = query.Where(t => t.TaskDateTime >= from && t.TaskDateTime < to);
            }

            // EXECUTE QUERY
            var data = query
                .OrderByDescending(t => t.TaskDateTime)
                .ToList();

            // EXTRACT RELATED IDS FOR MANUAL LOADING
            var userIds = data.Where(x => x.UserId != null)
                              .Select(x => x.UserId.Value)
                              .Distinct()
                              .ToList();

            var projectIds = data.Select(x => x.ProjectId)
                                 .Distinct()
                                 .ToList();

            // LOAD USERS INTO MEMORY
            var users = _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToList()
                .ToDictionary(u => u.Id, u => u.Username);

            // LOAD PROJECTS INTO MEMORY
            var projects = _context.Projects
                .AsNoTracking()
                .Where(p => projectIds.Contains(p.Id))
                .ToList()
                .ToDictionary(p => p.Id, p => p.ProjectName);

            // ATTACH NAVIGATION DATA MANUALLY
            foreach (var item in data)
            {
                if (item.UserId != null && users.ContainsKey(item.UserId.Value))
                    item.User = new User { Username = users[item.UserId.Value] };

                if (projects.ContainsKey(item.ProjectId))
                    item.Project = new Project { ProjectName = projects[item.ProjectId] };
            }

            vm.Results = data;

            // CALCULATE TOTAL HOURS
            vm.TotalHours = vm.Results.Sum(t =>
                (t.EndDateTime - t.TaskDateTime).TotalHours);

            return View(vm);
        }
    }
}

