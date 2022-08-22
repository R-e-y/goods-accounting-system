using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class RawPurchase
    {
        public int IdPur { get; set; }
        public int? Raw { get; set; }
        public int? Amount { get; set; }
        public int? Sum { get; set; }
        public int? Unit { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

      
        public virtual Raw RawNavigation { get; set; }
        public virtual Unit UnitNavigation { get; set; }
        public virtual Employee EmployeeNavigation { get; set; }
    }
}
