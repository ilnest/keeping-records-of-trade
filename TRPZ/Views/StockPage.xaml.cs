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
using TRPZ.Views;

namespace TRPZ
{
    /// <summary>
    /// Interaction logic for StockPage.xaml
    /// </summary>
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
            this.DataContext = new ModelView.StockPageVM(this);
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "NumberInStock")
            {
                e.Column.Header = "Number";
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (changeMode.IsChecked == true)
            {
                ChangeWindow window = new ChangeWindow(this);
                window.Show();
            }
            else
                MessageBox.Show("Выберите режим \"Выберите режим редактирования\"");
        }

        private void changeMode_Checked(object sender, RoutedEventArgs e)
        {
            if(ConnectionClass.CurrUser.AccessLevel != 3)
            {
                observeMode.IsChecked = true;
                MessageBox.Show("Недостаточный уровень доступа");
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (changeMode.IsChecked == true)
            {
                AddItemWindow window = new AddItemWindow(this);
                window.Show();
            }
            else
                MessageBox.Show("Выберите режим \"Выберите режим редактирования\"");
        }

        private void dellBtn_Click(object sender, RoutedEventArgs e)
        {
            Operations ops = new Operations();

            if (changeMode.IsChecked == true)
            {           
                Item item = (Item)grid.dataGrid.SelectedItem;
                if(item == null)
                {
                    MessageBox.Show("Выберите нужную позицию");
                    return;
                }
                ops.DellItem(item.ID);
            }
            else
                MessageBox.Show("Выберите режим \"Выберите режим редактирования\"");
            grid.dataGrid.ItemsSource = ops.GetItems();
        }
    }
}
