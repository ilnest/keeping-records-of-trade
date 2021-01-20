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
using System.Windows.Shapes;

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for UpdUserWindow.xaml
    /// </summary>
    public partial class UpdUserWindow : Window
    {
        private ModerPage page;
        private Operations ops;

        private User user;

        private string fname;
        private string lname;
        private string accessLevel;
        private string login;
        private string password;

        public UpdUserWindow(ModerPage page)
        {
            this.page = page;
            InitializeComponent();

            user = (User)page.dataGrid.SelectedItem;
            if(user == null)
            {
                MessageBox.Show("Вы не выбрали пользователя");
                this.Close();
            }

            ops = new Operations();

            fname = user.FName.Trim(' ');
            lname = user.LName.Trim(' ');
            accessLevel = Convert.ToString(user.AccessLevel).Trim(' ');
            login = user.Login.Trim(' ');
            password = user.Password.Trim(' ');

            fNameBox.Text = fname;
            lNameBox.Text = lname;
            accessBox.Text = accessLevel;
            loginBox.Text = login;
            passwordBox.Text = password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newFname = fNameBox.Text.Trim(' ');
            string newLname = lNameBox.Text.Trim(' ');
            string newAccessLevel = accessBox.Text.Trim(' ');
            string newLogin = loginBox.Text.Trim(' ');
            string newPassword = passwordBox.Text.Trim(' ');

            if (fname != newFname || lname != newLname || accessLevel != newAccessLevel || login != newLogin || password != newPassword)
            {
                ops.UpdateUser(new User(user.ID, newFname, newLname, Convert.ToInt32(newAccessLevel), newLogin, newPassword));
                page.dataGrid.ItemsSource = ops.GetUsers();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ничего не изменили");
                this.Close();
            }


        }
    }
}
