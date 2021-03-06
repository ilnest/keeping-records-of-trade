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
    class UpdUserCommand: ICommand
    {
        private ModerPage page;

#pragma warning disable CS0067 // The event 'UpdUserCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'UpdUserCommand.CanExecuteChanged' is never used

        public UpdUserCommand(ModerPage page)
        {
            this.page = page;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UpdUserWindow window = new UpdUserWindow(page);
            window.Show();
        }
    }
}
