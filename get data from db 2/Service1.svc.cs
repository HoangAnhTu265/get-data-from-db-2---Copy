using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace get_data_from_db_2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Student> getStudents()
        {
            List<Student> list = new List<Student>();
            list = TestSinhVien.getListStudents();
            return list;
        }

        public string InsertUserDetails(Student userInfo)
        {
            string Message;
            SqlConnection con = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=SinhVien222;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into sinhVien(Name,Email) values(@Name,@Email)", con);
            cmd.Parameters.AddWithValue("@Name", userInfo.Name);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
    
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = userInfo.Name + " Details inserted successfully";
            }
            else
            {
                Message = userInfo.Name + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        //public List<Student> getStudents()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
