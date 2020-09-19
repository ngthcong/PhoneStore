using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class Comment
    {
        public Comment()
        {
            InverseParent = new HashSet<Comment>();
        }

        public int ComId { get; set; }
        public int? ProId { get; set; }
        public string ComText { get; set; }
        public DateTime? ComTime { get; set; }
        public int? ComAccId { get; set; }
        public string ConCusName { get; set; }
        public string ComCusPhone { get; set; }
        public int? ParentId { get; set; }
        public string ConNote { get; set; }
        public bool? ComStatus { get; set; }

        public virtual Account ComAcc { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual Product Pro { get; set; }
        public virtual ICollection<Comment> InverseParent { get; set; }
    }
}
