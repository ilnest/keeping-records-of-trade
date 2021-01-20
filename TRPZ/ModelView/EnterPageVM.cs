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
using System.Collections.ObjectModel;
using TRPZ.ModelView.Commands;

namespace TRPZ.ModelView
{
    public class EnterPageVM
    {
        private EnterPage page;

        public ICommand LoginCommandProperty { get; set; }

        public EnterPageVM(EnterPage page)
        {
            this.page = page;
            LoginCommandProperty = new LoginCommand(page);
        }
    }
}
