using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client cl1 = new ServiceReference1.Service1Client();
            var myList = cl1.getListStudent();
            foreach(var s in myList)
            {
                Console.WriteLine(s.Name + " " + s.Email);
            }
            Console.ReadLine();
        }
    }
}
