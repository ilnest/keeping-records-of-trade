﻿using System;
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
    public class StockPageVM
    {
        private StockPage page;
        private Operations ops;

        public StockPageVM(StockPage page)
        {
            this.page = page;
            ops = new Operations();
            page.grid.dataGrid.ItemsSource = ops.GetItems();
        }



    }
}
