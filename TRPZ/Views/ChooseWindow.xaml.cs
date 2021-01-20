using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace TRPZ.ModelView.Commands
{
    /// <summary>
    /// Interaction logic for ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        private SellPageVM pageVM;
        private Operations ops;
        private SellPage page;

        public ChooseWindow(SellPageVM pageVM)
        {
            InitializeComponent();
            this.pageVM = pageVM;
            page = pageVM.Page;
            ops = new Operations();
            listOfItems.ItemsSource = ops.GetItems();

        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Item> listOfItemForPage;
            listOfItemForPage = pageVM.ItemsToSell;

            Item selectedItem = (Item)listOfItems.SelectedItem;


            if (selectedItem == null)
            {
                MessageBox.Show("Вы ничего не выбрали");
                return;
            }

            if (selectedItem.NumberInStock == 0)
            {
                MessageBox.Show("На складе не достаточно товара");
                return;
            }

            if (Convert.ToInt16(desiredNumber.Text) <= 0)
            {
                MessageBox.Show("Only unsigned number allowed!");
                return;
            }

            if (selectedItem.NumberInStock < Convert.ToInt32(desiredNumber.Text))
            {
                MessageBox.Show("На складе не достаточно товара");
                return;
            }

            foreach (Item item in ops.GetItems())
            {
                if (selectedItem.ID == item.ID)
                    selectedItem = item;
            }

            int desiredNumberInt = Convert.ToInt32(desiredNumber.Text);       


            double total = Convert.ToDouble(page.total.Text);
            total += (selectedItem.Price * desiredNumberInt);
            page.total.Text = total.ToString();

            Console.WriteLine(selectedItem.NumberInStock);
            Item check = null;
            foreach(Item item in listOfItemForPage)
            {
                if (item.ID == selectedItem.ID)
                {
                    check = item;
                    if ((desiredNumberInt + item.NumberInStock) > selectedItem.NumberInStock)
                    {
                        MessageBox.Show("На складе не достаточно товара, выберите меньше");
                        return;
                    }
                }
            }

            selectedItem.NumberInStock = desiredNumberInt; // specify desired number of item to display it in the DataGrid

            if (check != null)
            {
                listOfItemForPage.Remove(check);
                check.NumberInStock += selectedItem.NumberInStock;
                listOfItemForPage.Add(check);
                return;
            }
       
            listOfItemForPage.Add(selectedItem);
        }
    }
}
