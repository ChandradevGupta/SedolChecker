using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SedolChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please Enter a SEDOL");
            string userinput = Console.ReadLine();
            SedolValidator sedolValidator = new SedolValidator();
            var result = sedolValidator.ValidateSedol(userinput);
            Console.WriteLine(Convert.ToString(result.ValidationDetails));
            Console.ReadLine();
        }
    }

}
