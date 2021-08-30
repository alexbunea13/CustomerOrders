using CustomerOrders.Validators;
using CustomerOrders.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Models
{
    public static class CustomerOrdersMapper
    {
        public static CustomerOrdersViewModel ToDto(BigShoeDataImport.OrderLocalType order)
        {
            return new CustomerOrdersViewModel
            {
                CustomerEmail = order.CustomerEmail,
                CustomerName = order.CustomerName,
                DateRequired = order.DateRequired.Date,
                Notes = order.Notes,
                Quantity = order.Quantity,
                Size = order.Size
            };
        }
    }
}
