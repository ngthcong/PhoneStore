using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Employee
    {
        public int EmId { get; set; }
        public string EmName { get; set; }
        public string EmEmail { get; set; }
        public string EmSalt { get; set; }
        public string EmPass { get; set; }
        public string EmPhone { get; set; }
        public string EmIdentityNumber { get; set; }
        public DateTime? EmBirthday { get; set; }
        public string EmNote { get; set; }
        public int? EmRoleId { get; set; }
        public int? EmShiftId { get; set; }
        public bool? EmStatus { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual EmployeeRole EmRole { get; set; }
        public virtual EmployeeShift EmShift { get; set; }
    }
}
