using Microsoft.AspNetCore.Mvc;
using EmployeeTaskProgress.Models;

namespace EmployeeTaskProgress.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        // Get all clients
        public IActionResult Index()
        {
            var clients = _context.Clients.ToList();
            return View(clients);
        }

        // Show create form
        public IActionResult Create()
        {
            return View();
        }

        // Create client (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();

            return View(client);
        }

        // Update client (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Delete client
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);

            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}