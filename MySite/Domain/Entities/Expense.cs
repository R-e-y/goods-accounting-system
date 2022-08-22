using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Expense
    {
        public int IdExp { get; set; }
        public string Name { get; set; }
        public int? Sum { get; set; }
        public DateTime? Date { get; set; }
        public int? Employee { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }

    }
}
