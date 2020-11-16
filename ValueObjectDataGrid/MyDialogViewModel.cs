using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueObjectDataGrid
{
    public class MyDialogViewModel : ViewModelBase
    {
        public class ParVM : ViewModelBase
        {
            private MyDialogViewModel _mdVM;
            public string Name => _par?.Name;
            private int _val;
            public int Val {
                get => _val; 
                set { 
                    Set(() => Val, ref _val, value); 
                    _mdVM.UpdateVal(_par.Name, value);
                }
            }

            private Par _par;
            public ParVM( MyDialogViewModel mdVM,  Par par)
            {
                _mdVM = mdVM;
                _par = par;
                Val = _par.Val;
            }
        }

        private bool _initializing;
        private void UpdateVal(string name, int value)
        {
            if (!_initializing)
            _parService.UpdateVal(name, value);
        }

        private List<ParVM> _parVMs=new List<ParVM>();
        public IEnumerable<ParVM> ParVMs => _parVMs;

        private ParService _parService;
        public MyDialogViewModel(ParService parService)
        {
            _initializing = true;
            _parService = parService;
            foreach (var pa in parService.Pars)
                _parVMs.Add(new ParVM(this,pa));
            _initializing = false;
        }
    }
}
