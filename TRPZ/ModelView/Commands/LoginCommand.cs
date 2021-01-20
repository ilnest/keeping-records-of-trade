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
    public class LoginCommand : ICommand
    {
        private Operations ops;
        private EnterPage page;

        public LoginCommand(EnterPage page)
        {
            ops = new Operations();
            this.page = page;
        }

#pragma warning disable CS0067 // The event 'LoginCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'LoginCommand.CanExecuteChanged' is never used

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string login = page.loginBox.Text;
            string password = page.passwordBox.Text;
            Console.WriteLine("assaas");

            if (ops.Login(login, password))
            {
                page.NavigationService.Navigate(new Views.MainMenu());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }
    }
}
