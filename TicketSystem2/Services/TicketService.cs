using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;
using TicketSystem.ViewModels;
using TicketSystem2.DTOs;
using TicketSystem2.ViewModels;

namespace TicketSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _context;

        public TicketService(DBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResultDTO> Creat(CreatTicketModel input)
        {
            var result = new ResultDTO();

            var ticket = new T_Ticket()
            {
                Resolved = false,
                Summary = input.Summary,
                Description = input.Description,
            };
            await _context.T_Tickets.AddAsync(ticket);
            result.Success = (await _context.SaveChangesAsync()) > 0;

            return result;
        }

        public async Task<ResultDTO> Update(UpdateTicketModel input)
        {
            var result = new ResultDTO();

            var ticket = _context.T_Tickets.FirstOrDefault(t => t.ID == input.ID);
            if (ticket != null)
            {
                ticket.Summary = input.Summary;
                ticket.Description = input.Description;
                result.Success = (await _context.SaveChangesAsync()) > 0;
            }

            return result;
        }

        public async Task<ResultDTO> Resolve(int? id)
        {
            var result = new ResultDTO();

            if (id != null)
            {
                var ticket = _context.T_Tickets.FirstOrDefault(t => t.ID == id);
                if (ticket != null)
                {
                    ticket.Resolved = true;
                    result.Success = (await _context.SaveChangesAsync()) > 0;
                }
            }

            return result;
        }

        public async Task<ResultDTO> Delete(int? id)
        {
            var result = new ResultDTO();

            var ticket = _context.T_Tickets.FirstOrDefault(t => t.ID == id);
            if (ticket != null)
            {
                _context.T_Tickets.Remove(ticket);
                result.Success = (await _context.SaveChangesAsync()) > 0;
            }

            return result;
        }

        public async Task<ResultDTO> Get(int? id)
        {
            var result = new ResultDTO();

            if (id != null)
            {
                var ticket = _context.T_Tickets.FirstOrDefault(t => t.ID == id);
                if (ticket != null)
                {
                    result.Data = _mapper.Map<TicketModel>(await _context.T_Tickets.FirstOrDefaultAsync(t => t.ID == id));
                    result.Success = true;
                }
            }

            return result;
        }

        public async Task<IEnumerable<TicketModel>> GetList()
        {
            return _mapper.Map<IEnumerable<TicketModel>>(await _context.T_Tickets.ToListAsync());
        }
    }
}