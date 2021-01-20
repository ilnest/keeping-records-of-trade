using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using TRPZ.ModelView.Commands;

namespace TRPZ.ModelView
{
    public class SellPageVM : INotifyPropertyChanged
    {

        public ICommand ShowItems { get; set; }

        public ICommand SellCommand { get; set; }

        private ObservableCollection<Item> itemsToSell;

        public ObservableCollection<Item> ItemsToSell {
            get
            {
                return itemsToSell;
            }
            set
            {
                itemsToSell = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemsToSell"));
                }
            }
        }

        public SellPage Page { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SellPageVM(SellPage page)
        {
            Page = page;
            ShowItems = new ShowItemsToSellCommand(this, new Operations());
            SellCommand = new SellCommand(page);
            ItemsToSell = new ObservableCollection<Item>();
            Page.dataGrid.ItemsSource = ItemsToSell;
            Page.time.Text = DateTime.Now.ToString();
        }
    
    }
}
