using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ValueObjectDataGrid
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IEnumerable<Par> _pars ;
        public IEnumerable<Par> Pars { get => _pars; set { Set(() => Pars , ref _pars, value); }}



        private RelayCommand _showPars;
        public RelayCommand ShowPars => _showPars ?? (_showPars = new RelayCommand(
            () => showPars(),
            () => { return 1 == 1; },
			keepTargetAlive:true
            ));

        private void showPars()
        {
            MyDialog myDialog = new MyDialog();
            myDialog.Pars = Pars;
            myDialog.ShowDialog();
            Pars= myDialog.Pars;

        }

        public MainWindowViewModel()
        {
            List<Par> parsList = new List<Par>();
            parsList.Add(new Par.Builder().WithName("uno").WithVal(1).Build());
            parsList.Add(new Par.Builder().WithName("due").WithVal(2).Build());
            Pars = parsList;
        }

    }
}
