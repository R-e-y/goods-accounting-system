using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class ProdSale
    {
        public int IdSale { get; set; }
        public int? Product { get; set; }
        public int? Amount { get; set; }
        public int? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual FinishedProd ProductNavigation { get; set; }
    }
}
