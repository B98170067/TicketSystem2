using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services;
using TicketSystem.ViewModels;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {
        private ITicketService _ticketServicel;

        public TicketController(ITicketService ticketServicel)
        {
            _ticketServicel = ticketServicel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatTicketModel input)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UpdateTicketModel input)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Resolve(UpdateTicketModel input)
        {
            return View();
        }
    }
}