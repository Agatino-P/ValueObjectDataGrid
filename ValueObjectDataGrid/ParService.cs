using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueObjectDataGrid
{
    public class ParService
    {
        private List<Par> _pars= new List<Par>();
        public IEnumerable<Par> Pars => _pars;
        public void Add(Par par)
        {
            if (!(_pars.Any(p => p.Name == par.Name)))
                _pars.Add(par);
        }
        public void UpdateVal(string name, int val)
        {
            Par targetPar = _pars.FirstOrDefault(p => p.Name == name);
            if (targetPar != null)
            {
                Par newPar = new Par.Builder().WithName(name).WithVal(val).Build();
                _pars.Remove(targetPar);
                _pars.Add(newPar);
            }
        }
    }
}
