
using System;
using System.Collections.Generic;

#nullable disable

namespace MySite.Domain.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Expenses = new HashSet<Expense>();
            Manufactures = new HashSet<Manufacture>();
            ProdSales = new HashSet<ProdSale>();
            RawPurchases = new HashSet<RawPurchase>();
        }
        
        public int IdEmpl { get; set; }
        public string Name { get; set; }
        public int? Post { get; set; }
        public int? Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Premium { get; set; }

      
        public virtual Post PostNavigation { get; set; }
        
        public virtual ICollection<Manufacture> Manufactures { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<ProdSale> ProdSales { get; set; }
        public virtual ICollection<RawPurchase> RawPurchases { get; set; }
    }
}
