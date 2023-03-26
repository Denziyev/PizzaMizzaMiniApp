using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Core.Models
{
    public class Pizza
    {
        public string Name;
        public int Id;
        static int _count = 0;
        public string Ingredient;
        public Size PizzaSize;
        public enum Size { Small, Medium, Big }
        double _price;
        public double Price
        {
            get => _price;
            set
            {
                  _price=value;
            }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Size: {PizzaSize},  Price: {Price},  Id: {Id}";
        }
        public Pizza()
        {
            _count++;
            Id = _count;
        }
    }
}
