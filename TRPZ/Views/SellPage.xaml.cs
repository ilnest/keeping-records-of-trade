using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPZ
{
    /// <summary>
    /// Interaction logic for SellPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {

        public SellPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = new ObservableCollection<Item>();
            this.DataContext = new ModelView.SellPageVM(this);
            employee.Text = ConnectionClass.CurrUser.FName + " " + ConnectionClass.CurrUser.LName;
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "NumberInStock")
            {
                e.Column.Header = "Number";
            }
        }
    }
}
