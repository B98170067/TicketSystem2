using TicketSystem.ViewModels;
using TicketSystem2.DTOs;
using TicketSystem2.ViewModels;

namespace TicketSystem.Services
{
    public interface ITicketService
    {
        Task<ResultDTO> Creat(CreatTicketModel input);

        Task<ResultDTO> Update(UpdateTicketModel input);

        Task<ResultDTO> Resolve(int? id);

        Task<ResultDTO> Delete(int? id);

        Task<ResultDTO> Get(int? id);

        Task<IEnumerable<TicketModel>> GetList();
    }
}