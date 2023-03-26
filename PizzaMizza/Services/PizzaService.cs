using PizzaMizza.Abstractions;
using PizzaMizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMizza.Services
{
    public class PizzaService : IPizzaService<Pizza>
    {
        List<Pizza> pizzaList=new List<Pizza>();

        public void Create(Pizza pizza)
        {
            Console.WriteLine("Pizza adini daxil edin: ");
            string Name= Console.ReadLine();
            while (string.IsNullOrWhiteSpace(Name.Trim()))
            {
                Console.WriteLine("Pizza adini duzgun daxil edin: ");
                Name = Console.ReadLine();
            }
            pizza.Name = Name;
            Console.WriteLine(" ");
            bool status = false;
            while (!status)
            {
                Console.WriteLine("Gosterilen olculerden birini daxil edin: ");
                Console.WriteLine(Pizza.Size.Small);
                Console.WriteLine(Pizza.Size.Medium);
                Console.WriteLine(Pizza.Size.Big);
                string request = Console.ReadLine().ToLower().Trim();

                switch (request)
                {
                    case "small":
                        pizza.PizzaSize = Pizza.Size.Small;
                        status = true;
                        break;
                    case "medium":
                        pizza.PizzaSize = Pizza.Size.Medium;
                        status = true;
                        break;
                    case "big":
                        pizza.PizzaSize = Pizza.Size.Big;
                        status = true;
                        break;
                    default:
                        Console.WriteLine("Size duzgun daxil edin: ");
                        break;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Ingredientleri daxil edin:");
            string ing = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(ing))
            {
                Console.WriteLine("İngredientleri duzgun daxil edin: ");
                ing = Console.ReadLine();
            }
            pizza.Ingredient= ing;
            Console.WriteLine(" ");
            Console.WriteLine("Qiymeti daxil edin");
            string pprice= Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(pprice)|| pprice.Contains(","))
            {
                Console.WriteLine("Qiymeti duzgun daxil edin(Bosluqdan ve ya vergulden istifade etmeyin): ");
                Console.WriteLine("Qitmet 0-dan boyuk olmalidi: ");
                pprice = Console.ReadLine().Trim();
            }
            while (double.Parse(pprice) <= 0)
            {
                Console.WriteLine("Qiymeti duzgun daxil edin: ");
                pprice = Console.ReadLine().Trim();
            }
            pizza.Price= double.Parse(pprice);
            pizzaList.Add(pizza);
            Console.WriteLine(" ");
            Console.WriteLine("Pizza ugurla elave edildi");
            Console.WriteLine(" ");
        }

        public void Show()
        {
            if (pizzaList.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("-->> qaqa hele pizza yoxdu");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
            else
            {
                foreach (var pizza in pizzaList)
                {
                    Console.WriteLine(pizza);
                }

                Console.WriteLine(" ");

                Console.WriteLine("Pizzalar haqqinda etrafli melumat ucun 1 daxil edin: ");
                Console.WriteLine("cixis ucun 0 daxil edin: ");
                string requestt=Console.ReadLine().Trim();
                while (requestt != "0")
                {
                    switch (requestt)
                    {
                        case "1":
                            Console.WriteLine("Etrafli melumat elde etmek istediyiniz Pizzanin Id-ni daxil edin:");
                            GetbyId();
                            break;
                        default:
                            Console.WriteLine("Yalniz 0,1 reqemlerini daxil ede bilersiz.");
                            requestt = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine("Basqa pizzalar haqqinda etrafli melumat ucun 1 daxil edin: ");
                    Console.WriteLine("cixis ucun 0 daxil edin: ");
                    requestt = Console.ReadLine();
                    Console.WriteLine(" ");                    
                }
                
            }
            
        }

        public void  GetbyId()
        {
            
            int Id = int.Parse(Console.ReadLine().Trim());
            int count = 0;
            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Id == Id)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine($"--> Ingredientler: { pizzaList[i].Ingredient}");
                    Console.WriteLine(" ");
                    showallsize(pizzaList[i]);
                    count++;
                    
                }
                else if(i==pizzaList.Count-1 && count==0)
                {
                    Console.WriteLine("qaqa bele Id yoxdu.Yeniden daxil etmek ucun 1 reqemini daxil edin:");
                    Console.WriteLine("Cixis ucun 0 reqemini daxil edin: ");
                    string requesttt=Console.ReadLine().Trim();
                    Console.WriteLine(" ");
                    while(requesttt!="0")
                    {
                        switch(requesttt)
                        {
                            case "1":
                                Console.WriteLine("Pizzanin Id-ni duzgun daxil edin:");
                                GetbyId();
                                break;
                            default:
                                Console.WriteLine("Yalniz 0 ve 1 reqemlerini daxil ede bilersiz");
                                break;
                        }
                        requesttt = Console.ReadLine().Trim();
                    }
                                      
                }
            }
        }


        public void showallsize(Pizza pizza)
        {
            Console.WriteLine("--------  Bu pizzanin butun movcud olculeri ucun melumatlar: ---------");
            int count = 0;
            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Name == pizza.Name)
                {
                    count++;
                    Console.WriteLine(" ");
                    Console.WriteLine($"{pizzaList[i].PizzaSize} size ucun melumatlar ----->: {pizzaList[i]}");

                }             
            }
            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        public void Delete()
        {
            if (pizzaList.Count == 0)
            {
                Console.WriteLine("qaqa hele pizza yoxdu");
            }
            else
            {
                Console.WriteLine("Delete etmek istediyiniz Id-ni daxil edin: ");
                int delid = int.Parse(Console.ReadLine())-1;
                if (delid >= 0&& delid<pizzaList.Count)
                {

                    pizzaList.Remove(pizzaList[delid]);
                    Console.WriteLine("Delete Pizza emeliyyati ugurla bitdi");
                }
                else
                {
                    Console.WriteLine("Bele id movcud deyil");
                }

            }
        }


        
    }
}
