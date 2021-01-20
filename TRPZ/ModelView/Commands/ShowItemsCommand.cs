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

namespace TRPZ.ModelView.Commands
{
    class ShowItemsToSellCommand : ICommand
    {
        private Operations _ops;
        private SellPageVM _page;

        public ShowItemsToSellCommand(SellPageVM page, Operations ops)
        {
            _page = page;
            _ops = ops;
        }

#pragma warning disable CS0067 // The event 'ShowItemsToSellCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'ShowItemsToSellCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ChooseWindow window = new ChooseWindow(_page);
            window.Show();
        }
    }
}
