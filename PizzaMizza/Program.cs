using PizzaMizza.Abstractions;
using PizzaMizza.Core.Models;
using PizzaMizza.Services;
using System.Security.Cryptography.X509Certificates;

PizzaService pizzaService =new PizzaService();


Console.WriteLine("- - - - - - - - Qaqa PizzaMizzaya xos gelmisen.Hemise sen gelesen(-_-) - - - - - - - -");
Console.WriteLine(" ");
Console.WriteLine("--> Yeni pizza elave etmek ucun 1 reqemini daxil edin");
Console.WriteLine("--> Konsolu baglamaq ucun 0 reqemini daxil edin");
string request = Console.ReadLine();
Console.WriteLine(" ");

while (request != "0")
{
    switch (request)
    {
        
        case "1":
            Pizza pizza = new Pizza();
            pizzaService.Create(pizza);
            break;
        case "2":
            pizzaService.Show();
            break;
        case "3":
            pizzaService.Delete();
            break;
        
        default:
            Console.WriteLine("qaqa yalniz 0,1,2 reqemlerini daxil ede bilersen");
            break;


    }
    
    Console.WriteLine("--> Yeni pizza elave etmek ucun 1 reqemini daxil edin");
    Console.WriteLine("--> Movcud pizzalari gormek ucun 2 reqemini daxil edin");
    Console.WriteLine("--> Her hansi Pizzani silmek ucun 3 reqemini daxil edin");
    
    Console.WriteLine("--> Konsolu baglamaq ucun 0 reqemini daxil edin");
     request = Console.ReadLine();
}
