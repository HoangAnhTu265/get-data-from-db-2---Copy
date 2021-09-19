using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace service_bus
{
    public class testStudent
    {
        public static List<Student> getListStudent()
        {
            List<Student> list = new List<Student>();

            list.Add(new Student() { Email = "tuhoang@gmail.com", Name = "Tu" });
            list.Add(new Student() { Email = "phuoc@gmail.com", Name = "Phuoc" });
            return list;
        }
    }
}