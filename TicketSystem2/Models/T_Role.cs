using System;
using System.Collections.Generic;

namespace TicketSystem.Models
{
    public partial class T_Role
    {
        public T_Role()
        {
            Permissions = new HashSet<T_Permission>();
            Users = new HashSet<T_User>();
        }

        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<T_Permission> Permissions { get; set; }
        public virtual ICollection<T_User> Users { get; set; }
    }
}
