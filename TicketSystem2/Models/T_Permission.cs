using System;
using System.Collections.Generic;

namespace TicketSystem.Models
{
    public partial class T_Permission
    {
        public T_Permission()
        {
            Roles = new HashSet<T_Role>();
        }

        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public string Action { get; set; } = null!;

        public virtual ICollection<T_Role> Roles { get; set; }
    }
}
