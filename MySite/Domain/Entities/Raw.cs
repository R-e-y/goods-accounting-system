using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Raw
    {
        public Raw()
        {
            Ingredients = new HashSet<Ingridient>();
            RawPurchases = new HashSet<RawPurchase>();
        }

        public int IdRaw { get; set; }
        public string Name { get; set; }
        public int? Unit { get; set; }
        public int? Sum { get; set; }
        public int? Amount { get; set; }

        public virtual ICollection<Ingridient> Ingredients { get; set; }
        public virtual ICollection<RawPurchase> RawPurchases { get; set; }
        public virtual Unit UnitNavigation { get; set; }
    }
}
