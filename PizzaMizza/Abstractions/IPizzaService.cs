using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Abstractions
{
    public interface IPizzaService<Pizza> 
    {
        public void Create(Pizza pizza);
        public void Show();

        public void Delete();
    }
}
