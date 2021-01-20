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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for DeliverPage.xaml
    /// </summary>
    public partial class DeliverPage : Page
    {
        public DeliverPage()
        {
            InitializeComponent();
            this.DataContext = new ModelView.DeliverPageVM(this);
        }

        private void executeBtn_Click(object sender, RoutedEventArgs e)
        {
            int amount = Convert.ToInt32(amountBox.Text);
            if(amount <= 0)
            {
                Console.WriteLine("Недопустимое значение");
                return;
            }

            Item item = (Item)dataGrid.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            Operations ops = new Operations();
            ops.Deliver(item.ID, amount);
            dataGrid.ItemsSource = ops.GetItems();
        }
    }
}
