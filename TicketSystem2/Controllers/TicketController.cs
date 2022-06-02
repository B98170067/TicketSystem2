using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services;
using TicketSystem.ViewModels;

namespace TicketSystem2.Controllers
{
    public class TicketController : Controller
    {
        private ITicketService _ticketServicel;

        public TicketController(ITicketService ticketServicel)
        {
            _ticketServicel = ticketServicel;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ticketServicel.GetList());
        }

        [Authorize(Roles = "QA")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "QA")]
        public async Task<IActionResult> Create(CreatTicketModel input)
        {
            if (ModelState.IsValid)
            {
                await _ticketServicel.Creat(input);
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }

        [Authorize(Roles = "QA")]
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
        [Authorize(Roles = "QA")]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "QA")]
        public async Task<IActionResult> Delete(int? id)
        {
            var result = await _ticketServicel.Delete(id);
            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RD")]
        public async Task<IActionResult> Resolve(int? id)
        {
            var result = await _ticketServicel.Resolve(id);
            return Json(result);
        }
    }
}