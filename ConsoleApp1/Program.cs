using ConsoleApp1.ServiceReference1;
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
            ServiceReference1.Service1Client sv = new ServiceReference1.Service1Client();

            Student student = new Student() {Name = Console.ReadLine(),Email = Console.ReadLine()};


            sv.InsertUserDetails(student);
            Console.WriteLine("đã in sớt thành công");
            var aaa = sv.getStudents();
            foreach(var m in aaa)
            {
                Console.WriteLine(m.Id + " " + m.Name + " " + m.Email);
            }
            Console.ReadLine();
        }
    }
}
