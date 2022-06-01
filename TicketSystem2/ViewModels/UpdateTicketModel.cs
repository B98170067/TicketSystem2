using System.ComponentModel.DataAnnotations;

namespace TicketSystem.ViewModels
{
    public class UpdateTicketModel
    {
        [Required]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Summary { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Description { get; set; }
    }
}