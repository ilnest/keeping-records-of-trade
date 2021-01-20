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
using System.Collections.ObjectModel;

namespace TRPZ.ModelView.Commands
{
    class SellCommand : ICommand
    {
        private Operations _ops;
        private SellPage _page;

        public SellCommand(SellPage page)
        {
            _page = page;
            _ops = new Operations();
        }

#pragma warning disable CS0067 // The event 'SellCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'SellCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ObservableCollection<Item> listOfItemForPage;
            listOfItemForPage = _page.dataGrid.ItemsSource as ObservableCollection<Item>;

            foreach(Item item in listOfItemForPage)
            {
                _ops.Sell(item.ID, item.NumberInStock);
            }

            _page.total.Text = "0";
            _page.dataGrid.ItemsSource = new ObservableCollection<Item>();
        }
    }
}
