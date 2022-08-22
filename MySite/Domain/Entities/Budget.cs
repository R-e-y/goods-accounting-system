using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Budget
    {
        public int IdBudget { get; set; }
        public decimal? Sum { get; set; }
    }
}
