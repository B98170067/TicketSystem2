using System;
using System.Collections.Generic;

namespace TicketSystem.Models
{
    public partial class T_Parameter
    {
        public int ID { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
