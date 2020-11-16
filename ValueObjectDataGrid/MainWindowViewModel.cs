using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Windows;

namespace ValueObjectDataGrid
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ParService _parService = new ParService();


        private RelayCommand _editParsCmd;
        public RelayCommand EditParsCmd => _editParsCmd ?? (_editParsCmd = new RelayCommand(
            () => editPars(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));
        private void editPars()
        {
            MyDialogViewModel myDialogViewModel = new MyDialogViewModel(_parService);
            MyDialog myDialog = new MyDialog(myDialogViewModel);
            myDialog.ShowDialog();
        }

        private RelayCommand _showParsCmd;
        public RelayCommand ShowParsCmd => _showParsCmd ?? (_showParsCmd = new RelayCommand(
            () => showPars(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));
        private void showPars()
        {
            string msg = string.Join(Environment.NewLine, _parService.Pars.Select(par => $"{par.Name}-{par.Val}"));
            MessageBox.Show(msg);
        }

        public MainWindowViewModel()
        {
            _parService.Add(new Par.Builder().WithName("uno").WithVal(1).Build());
            _parService.Add(new Par.Builder().WithName("due").WithVal(2).Build());
        }

    }
}
