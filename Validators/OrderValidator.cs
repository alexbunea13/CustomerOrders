using CustomerOrders.Models;
using CustomerOrders.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Validators
{
    public class OrderValidator : IModelValidator<CustomerOrdersViewModel>
    {
        public ValidationResult Validate(CustomerOrdersViewModel model, string prefix = null)
        {
            if(model == null)
                return new ValidationResult("/", "Order is null");

            var validationResult = new ValidationResult();

            if(string.IsNullOrEmpty(model.CustomerName))
                validationResult.AddError("name", "Name is not provided.");

            if (!IsValidEmail(model.CustomerEmail))
                validationResult.AddError("email", "Email is not valid.");

            if (!IsValidDate(model.DateRequired))
                validationResult.AddError("date", "Date must be at least 10 working days into the future.");

            if(!IsValidSize(model.Size))
                validationResult.AddError("size", "Size must be 11.5 to 15 including half sizes");

            if (!IsValidQuantity(model.Quantity))
                validationResult.AddError("quantity", "Quantity must be in multiples of 1000");

            return validationResult;
        }

        public static bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }

        public static bool IsValidDate(DateTime date)
        {
            var today = DateTime.Today.Date;

            int ndays = 1 + Convert.ToInt32((date - today).TotalDays);
            int nsaturdays = (ndays + Convert.ToInt32(today.DayOfWeek)) / 7;
            var difference = ndays - 2 * nsaturdays
                   - (today.DayOfWeek == DayOfWeek.Sunday ? 1 : 0)
                   + (date.DayOfWeek == DayOfWeek.Saturday ? 1 : 0);

            return difference >= 10;
        }

        public static bool IsValidSize(float size)
        {
            return size >= 11.5 && size <= 15 && size % 0.5 == 0;
        }

        public static bool IsValidQuantity(short quantity)
        {
            return quantity % 1000 == 0 && quantity > 0;
        }
    }
}
