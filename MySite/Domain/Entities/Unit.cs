using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Unit
    {
        public Unit()
        {
            FinishedProds = new HashSet<FinishedProd>();
            Raws = new HashSet<Raw>();          
            RawPurchases = new HashSet<RawPurchase>();
        }

        public int IdUnit { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FinishedProd> FinishedProds { get; set; }
        public virtual ICollection<Raw> Raws { get; set; }
        public virtual ICollection<RawPurchase> RawPurchases { get; set; }
    }
}
