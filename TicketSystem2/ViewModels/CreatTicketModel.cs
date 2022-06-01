using System.ComponentModel.DataAnnotations;

namespace TicketSystem.ViewModels
{
    public class CreatTicketModel
    {
        [Required(AllowEmptyStrings = false)]
        public string? Summary { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Description { get; set; }
    }
}