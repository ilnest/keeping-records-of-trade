﻿using System;
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
using TRPZ.Views;


namespace TRPZ.ModelView.Commands
{
    class DeliverPageCommand : ICommand
    {
        private MainMenu page;

        public DeliverPageCommand(MainMenu page)
        {
            this.page = page;
        }

#pragma warning disable CS0067 // The event 'DeliverPageCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'DeliverPageCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (ConnectionClass.CurrUser.AccessLevel == 2 || ConnectionClass.CurrUser.AccessLevel == 3)
            {
                page.NavigationService.Navigate(new DeliverPage());
            }
            else
            {
                MessageBox.Show("Регистрировать поставку могут только кладовщики и администраторы");
            }
        }
    }
}
