using System;
using System.Collections.Generic;

namespace PhoneStore.Data
{
    public partial class VarImages
    {
        public int ImgId { get; set; }
        public int? VarId { get; set; }
        public string ImgPath { get; set; }
        public int? ImgIndex { get; set; }

        public virtual ProVariant Var { get; set; }
    }
}
