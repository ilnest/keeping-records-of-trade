using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TRPZ
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        [DisplayName()]
        public int NumberInStock { get; set; }

        public Item(int id, string name, double price, string prod, int number)
        {
            ID = id;
            
            Name = name;
            Price = price;
            Producer = prod;
            NumberInStock = number;
        }

        public override string ToString()
        {
            return string.Format("\tID: {4}\n\tName: {0}\n\tPrice: ${1}\n\tProducer: {2}\n\tNumber in stock: {3}", Name, Price, Producer, NumberInStock, ID);
        }

    }
}
