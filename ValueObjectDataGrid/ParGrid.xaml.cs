using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValueObjectDataGrid
{
    /// <summary>
    /// Interaction logic for ParGrid.xaml
    /// </summary>
    public partial class ParGrid : UserControl
    {
        public class ParVM : ViewModelBase
        {
            private Par _par;
            public string Name => _par?.Name;

            private int _val; public int Val { 
                get => _val; 
                set { 
                    Set(() => Val, ref _val, value);
                    _par = new Par.Builder().WithName(_par.Name).WithVal(value).Build();
                }
            }

            //public static implicit operator ParVM(Par par) => new ParVM() { _par=par, Val=par.Val};
            //public static implicit operator Par(ParVM parVM) => parVM._par;

            public ParVM(Par par)
            {
                _par = par;
                Val = _par.Val;
            }

        }
        public IEnumerable<Par> Pars
        {
            get { return (IEnumerable<Par> )GetValue(ParsProperty); }
            set { SetValue(ParsProperty, value); }
        }
        public static readonly DependencyProperty ParsProperty =
            DependencyProperty.Register("Pars", typeof(IEnumerable<Par> ), typeof(ParGrid), new PropertyMetadata(null));




        public ParGrid()
        {
            InitializeComponent();
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Pars!= null)
            {

            ObservableCollection<ParVM> parVMs = 
                new ObservableCollection<ParVM>(
                    Pars.Select(par => (new ParVM (par))))
                ;
            dg.ItemsSource = parVMs;
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            var parVMs=dg.ItemsSource.Cast<ParVM>();
            Pars = parVMs.Select(parVM => new Par.Builder().WithName(parVM.Name).WithVal(parVM.Val).Build());
        }
    }
}
