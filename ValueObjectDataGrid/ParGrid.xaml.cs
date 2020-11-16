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
        public IEnumerable<MyDialogViewModel.ParVM> ParVMs
        {
            get { return (IEnumerable<MyDialogViewModel.ParVM>)GetValue(ParVMsProperty); }
            set { SetValue(ParVMsProperty, value); }
        }
        public static readonly DependencyProperty ParVMsProperty =
            DependencyProperty.Register("ParVMs", typeof(IEnumerable<MyDialogViewModel.ParVM>), typeof(ParGrid), new PropertyMetadata(null));

        public ParGrid()
        {
            InitializeComponent();
        }
    }
}
