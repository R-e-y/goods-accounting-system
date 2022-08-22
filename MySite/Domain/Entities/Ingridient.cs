using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Ingridient
    {
        public int IdIngr { get; set; }
        public int? Product { get; set; }
        public int? Raw { get; set; }
        public int? Amount { get; set; }

        public virtual FinishedProd ProductNavigation { get; set; }
        public virtual Raw RawNavigation { get; set; }
    }
}
