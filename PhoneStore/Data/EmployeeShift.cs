using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class EmployeeShift
    {
        public EmployeeShift()
        {
            Employee = new HashSet<Employee>();
        }

        public int ShiftId { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public int? ShiftNumber { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
