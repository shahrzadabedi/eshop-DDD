using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Model
{
    public class SalesOrderItemId : ValueObject
    {
        public int Value { get; private set; }
        public SalesOrderItemId(int value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Value;
        }
    }
}
