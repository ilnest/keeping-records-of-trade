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
using TRPZ.Views;

namespace TRPZ.ModelView.Commands
{
    class DellUserCommand : ICommand
    {
        private ModerPage page;
        private Operations ops;

#pragma warning disable CS0067 // The event 'DellUserCommand.CanExecuteChanged' is never used
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // The event 'DellUserCommand.CanExecuteChanged' is never used

        public DellUserCommand(ModerPage page)
        {
            this.page = page;
            ops = new Operations();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            User user = (User)page.dataGrid.SelectedItem;
            ops.DeleteUser(user.ID);
            page.dataGrid.ItemsSource = ops.GetUsers();
        }
    }
}
