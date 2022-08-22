using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class FinishedProd
    {
        public FinishedProd()
        {
            Ingredients = new HashSet<Ingridient>();
            Manufactures = new HashSet<Manufacture>();
            ProdSales = new HashSet<ProdSale>();
        }

        public int IdProd { get; set; }
        public string Name { get; set; }
        public int? Unit { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public int? Markup { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Ingridient> Ingredients { get; set; }
        public virtual ICollection<Manufacture> Manufactures { get; set; }
        public virtual ICollection<ProdSale> ProdSales { get; set; }
    }
}
