using CustomerOrders.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Models
{
    public class CustomerOrdersViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public short Quantity { get; set; }
        public string Notes { get; set; }
        public float Size { get; set; }
        public DateTime DateRequired { get; set; }
        public ValidationResult ValidationStatus { get; set; }
    }
}
