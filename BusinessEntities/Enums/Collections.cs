using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Enums
{
    public sealed class Collections
    {
        public static readonly Collections News = new Collections("News");

        private Collections(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(Collections op) { return op.Value; }
    }
}
