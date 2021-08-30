using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Validators
{
    public class ValidationResult
    {
        public bool IsValid => this.Errors.Count == 0;

        public IList<KeyValuePair<string, string>> Errors { get; } = new List<KeyValuePair<string, string>>();

        public ValidationResult() { }

        public ValidationResult(string propertyName, string errorMessage) => this.Errors.Add(new KeyValuePair<string, string>(propertyName, errorMessage));

        public void AddError(string propertyName, string errorMessage)
            => this.Errors.Add(new KeyValuePair<string, string>(propertyName, errorMessage));
    }
}
