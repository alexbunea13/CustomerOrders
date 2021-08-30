using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Validators.Abstractions
{
    public interface IModelValidator<in T> where T : class
    {
        ValidationResult Validate(T model, string prefix = null);
    }
}
