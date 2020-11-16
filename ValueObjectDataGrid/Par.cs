using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueObjectDataGrid
{
    public class Par : ValueObject
    {
        public string Name { get; private set; }
        public int Val { get; private set; }
        private Par()
        {

        }

        public class Builder
        {
            private Par _par = new Par();
            public Builder WithName(string name)
            {
                _par.Name = name;
                return this;
            }
            public Builder WithVal(int val)
            {
                _par.Val= val;
                return this;
            }
            public Par Build() => _par;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Val;
        }
    }
}
