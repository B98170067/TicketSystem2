using System;
using System.Collections.Generic;

namespace TicketSystem.Models
{
    public partial class T_Ticket
    {
        public int ID { get; set; }
        public bool Resolved { get; set; }
        public string? Severity { get; set; }
        public string? Priority { get; set; }
        public string Summary { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
