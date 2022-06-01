using AutoMapper;
using TicketSystem.Models;
using TicketSystem2.ViewModels;

namespace TicketSystem2.Mappings
{
    public class TicketMapping : Profile
    {
        public TicketMapping()
        {
            CreateMap<T_Ticket, TicketModel>();
        }
    }
}