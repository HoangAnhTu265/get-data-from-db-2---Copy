using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace service_bus
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public String Name{ get; set; }

        [DataMember]
        public String Email{ get; set; }

    }
}