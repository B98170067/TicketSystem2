using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Services;
using TicketSystem.ViewModels;

namespace TicketSystem2.Controllers
{
    public class T_TicketController : Controller
    {
        private readonly DBContext _context;
        private ITicketService _ticketServicel;

        public T_TicketController(DBContext context, ITicketService ticketServicel)
        {
            _context = context;
            _ticketServicel = ticketServicel;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ticketServicel.GetList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatTicketModel input)
        {
            if (ModelState.IsValid)
            {
                await _ticketServicel.Creat(input);
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var result = await _ticketServicel.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateTicketModel input)
        {
            if (ModelState.IsValid)
            {
                var result = await _ticketServicel.Update(input);
                if (result.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(input);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var result = await _ticketServicel.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var result = await _ticketServicel.Delete(id);
            if (result.Success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}