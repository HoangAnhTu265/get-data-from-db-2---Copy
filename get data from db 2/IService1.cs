using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace get_data_from_db_2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        List<Student> getStudents();

        [OperationContract]
        String InsertUserDetails(Student userInfo);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String Name { get; set; }


        [DataMember]
        public String Email { get; set; }

    }

    public class TestSinhVien
    {
        static SqlConnection con = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=SinhVien222;Integrated Security=True");

        static String sql_cmd = "Select * from sinhVien";

        public static List<Student> getListStudents()
        {
            List<Student> list = new List<Student>();


            SqlCommand cmd = new SqlCommand(sql_cmd, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Open();

            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Student std = new Student();
                std.Id = (int)read["Id"];
                std.Name = read["Name"].ToString();
                std.Email = read["Email"].ToString();

                list.Add(std);
            }
            con.Close();
            return list;
        }
    }
}
