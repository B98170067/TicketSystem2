using System;
using System.Collections.Generic;

namespace TicketSystem.Models
{
    public partial class T_User
    {
        public T_User()
        {
            Roles = new HashSet<T_Role>();
        }

        public int ID { get; set; }
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;

        public virtual ICollection<T_Role> Roles { get; set; }
    }
}
