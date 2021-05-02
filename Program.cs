using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempratureProject
{
    class Program
    {
        class Operation
        {
            internal string Key;
            internal string From;
            internal string To;
            internal Func<double, double> Function;
        }
        static string Message = "If you wish to convert {0} to {1}, Press {2}";
        static string ResultMessage = "The value of {0} degrees {2} is equal to {1} degrees {3}";
        static List<Operation> operations = new List<Operation> {
        new Operation { Key = "1", From="Fahrenheit", To="Celsius", Function = (CTempIn) => (CTempIn - 32 ) * 5 / 9 },
        new Operation { Key = "2", From="Fahrenheit", To="Kelvin", Function = (CTempIn) => (CTempIn - 32) * 5 / 9 + 273.15 },
        new Operation { Key = "3", From="Celsius", To="Fahrenheit", Function = (CTempIn) => (CTempIn * 9 / 5) + (32) },
        new Operation { Key = "4", From="Celsius", To="Kelvin", Function = (CTempIn) => CTempIn + 273.15 },
        new Operation { Key = "5", From="Kelvin", To="Fahrenheit", Function = (CTempIn) => (CTempIn - 273.15) * 9 / 5 + 32 },
        new Operation { Key = "6", From="Kelvin", To="Celsius", Function = (CTempIn) => CTempIn - 273.15 }
    };
        static void Main(string[] args)
        {

            //Ask for the temprature that the user wants to convert
            Console.WriteLine("What is the temprature you wish to convert?");
            var RInput = Console.ReadLine();
            double dInput = Convert.ToDouble(RInput);
            //Ask for what type of conversion
            foreach (var item in operations)
            {
                Console.WriteLine(Message, item.From, item.To, item.Key);
            }
            var YInput = Console.ReadLine();

            var operation = operations.Where(o => o.Key.Equals(YInput)).SingleOrDefault();
            if (operation == null)
            {
                Console.WriteLine("invalid input");
                Console.ReadLine();
                return;
            }
            Console.WriteLine(ResultMessage, dInput, operation.Function(dInput), operation.From, operation.To);
            Console.ReadLine();

        }

    }
    
}