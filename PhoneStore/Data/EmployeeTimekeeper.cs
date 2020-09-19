using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class EmployeeTimekeeper
    {
        public string Id { get; set; }
        public int? EmId { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
