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
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private ModerPage page;
        private Operations ops;

        private string fname;
        private string lname;
        private int accessLevel;
        private string login;
        private string password;

        public AddUserWindow(ModerPage page)
        {
            InitializeComponent();
            this.page = page;
            ops = new Operations();

            this.Height = 1;
            this.Width = 1;
            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = 1;
            heightAnimation.To = 420;
            heightAnimation.Duration = TimeSpan.FromSeconds(1);
            this.BeginAnimation(Window.HeightProperty, heightAnimation);

            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = 1;
            widthAnimation.To = 300;
            widthAnimation.Duration = TimeSpan.FromSeconds(2);
            this.BeginAnimation(Window.WidthProperty, widthAnimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fname = fNameBox.Text.Trim(' ');
            lname = lNameBox.Text.Trim(' ');
            accessLevel = Convert.ToInt32(accessBox.Text.Trim(' '));
            login = loginBox.Text.Trim(' ');
            password = passwordBox.Text.Trim(' ');


            ops.AddNewUser(fname, lname, accessLevel, login, password);
            page.dataGrid.ItemsSource = ops.GetUsers();
            this.Close();
        }
    }
}
