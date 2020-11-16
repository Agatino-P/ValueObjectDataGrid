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
using System.Windows.Shapes;

namespace ValueObjectDataGrid
{
    /// <summary>
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {
        public ObservableCollection<Par> Pars { get; set; }

        public MyDialog()
        {
            InitializeComponent();
            
        }

        private void mydlg_Loaded(object sender, RoutedEventArgs e)
        {
            pg.Pars = Pars;
        }
    }
}
