using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class AccRole
    {
        public AccRole()
        {
            Account = new HashSet<Account>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
