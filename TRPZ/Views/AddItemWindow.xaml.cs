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
using System.Windows.Shapes;

namespace TRPZ.Views
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private StockPage page;
        private Operations ops;

        private string name;
        private string producer;
        private double price;



        public AddItemWindow(StockPage page)
        {
            InitializeComponent();
            this.page = page;
            ops = new Operations();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = NameBox.Text.Trim(' ');
            producer = ProducerBox.Text.Trim(' ');
            price = Convert.ToDouble(PriceBox.Text.Trim(' '));

            ops.AddNewItem(name, price, producer);
            page.grid.dataGrid.ItemsSource = ops.GetItems();
            this.Close();
        }
    }
}