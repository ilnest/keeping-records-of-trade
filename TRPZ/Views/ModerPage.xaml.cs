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

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for ModerPage.xaml
    /// </summary>
    public partial class ModerPage : Page
    {
        public ModerPage()
        {
            InitializeComponent();
            this.DataContext = new ModelView.ModerPageVM(this);
            Operations ops = new Operations();
            dataGrid.ItemsSource = ops.GetUsers();
        }
    }
}
