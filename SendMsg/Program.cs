using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = "Y";
            while (flag == "Y" || flag == "y") {
                Console.WriteLine("Please input your message:");
                var msg = Console.ReadLine();

                ServiceBusService.ServiceBusService.SendMsg(msg);

                Console.WriteLine("Completed!");
                Console.WriteLine("Continue?(Y/N)");
                flag = Console.ReadLine();
            }

            Console.WriteLine("Game over! Bye Bye!");
            Console.ReadKey();
        }
    }
}
