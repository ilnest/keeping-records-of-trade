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
using System.Windows.Threading;
using System.Collections.ObjectModel;
using TRPZ.ModelView.Commands;
using TRPZ.Views;

namespace TRPZ.ModelView
{
    public class MainMenuVM : INotifyPropertyChanged
    {
        private MainMenu page;

        public ICommand ToSellPage { get; set; }

        public ICommand ToStockPage { get; set; }

        public ICommand ToDeliverPage { get; set; }

        public ICommand ToModerPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainMenuVM(MainMenu page)
        {
            this.page = page;
            page.employee.Text = ConnectionClass.CurrUser.FName + " " + ConnectionClass.CurrUser.LName;
            page.currTime.Text = DateTime.Now.ToString();
            ToSellPage = new SellPageCommand(page);
            ToStockPage = new StockPageCommand(page);
            ToDeliverPage = new DeliverPageCommand(page);
            ToModerPage = new ModerPageCommand(page);
        }
    }
}
