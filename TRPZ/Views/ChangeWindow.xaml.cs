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
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        private Item item;
        private StockPage page;
        private string name;
        private string price;
        private string producer;
        private string number;

        public ChangeWindow(StockPage stockPage)
        {
            InitializeComponent();
            page = stockPage;
            item = (Item)page.grid.dataGrid.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Выберите нужную позицию");
                this.Close();
            }

            name = item.Name.Trim(' ');
            price = (item.Price).ToString().Trim(' ');
            producer = item.Producer.Trim(' ');
            number = (item.NumberInStock).ToString().Trim(' ');

            this.Opacity = 0;
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.From = this.Opacity;
            opacityAnimation.To = 1.0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(1);
            this.BeginAnimation(Window.OpacityProperty, opacityAnimation);

            NameBox.Text = name;
            PriceBox.Text = price;
            ProducerBox.Text = producer;
            NumberBox.Text = number;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (page.changeMode.IsChecked != true)
            {
                
            }

            string newName = NameBox.Text.Trim(' ');
            string newPrice = PriceBox.Text.Trim(' ');
            string newProducer = ProducerBox.Text.Trim(' ');
            string newNumber = NumberBox.Text.Trim(' ');

            if(name != newName || price != newPrice || producer != newProducer || number != newNumber)
            {
                Item newItem = new Item(item.ID, newName, Convert.ToDouble(newPrice), newProducer, Convert.ToInt32(newNumber));
                Operations ops = new Operations();
                ops.UpdateItem(newItem);
                page.grid.dataGrid.ItemsSource = ops.GetItems();
                this.Close();
            }
        }
    }
}
