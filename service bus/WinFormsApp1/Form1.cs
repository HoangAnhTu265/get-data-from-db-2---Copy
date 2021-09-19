using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MqttClient mqttClient = null;

        String server = "150.95.112.175";  // txtServer.Text;
        int port = 1883;
        String topic = "a1908g";

        delegate void Mydelega(String messge);
        event Mydelega myRecive;

        delegate string empString(String str1,String str2);
        event empString pointer1;

        public String testPointer1(String str1,String str2)
        {
            string a = "abc";
            richTextBox1.Text += "\n abc";
            return a;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttClient(server, port, false, MqttSslProtocols.TLSv1_0, null, null);
            }
            if (mqttClient != null && mqttClient.IsConnected == false)
            {
                string clientId = Guid.NewGuid().ToString();
                mqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
                mqttClient.Connect(clientId);

                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                richTextBox1.Text += "chuoi " + clientId;
            }
            this.Text = "đã kết nối" + mqttClient.IsConnected;
            //Subcriable();

            pointer1 += Form1_pointer1;
            pointer1 += testPointer1;
        }

        private string Form1_pointer1(string str1, string str2)
        {
            //throw new NotImplementedException();
            return "Tú đẹp trai";
        }

        void Subcriable()
        {

            // mqttClient.Subscribe(new string[] { topic }, new byte[] { 0, 2 });
            if (mqttClient != null && mqttClient.IsConnected)
            {
                String[] topics = { topic, "a1908g2" };
                byte[] myByte = new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
                mqttClient.Subscribe(topics, myByte);


                MessageBox.Show("Đã subcriable " + topic);
            }

        }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            byte[] dataNhanVe = e.Message;
            String data = System.Text.ASCIIEncoding.UTF8.GetString(e.Message);
            myRecive = new Mydelega(ReciveData);
            this.Invoke(myRecive, new String[] { data });
            this.Invoke(pointer1, new String[] { data,data });
            
        }
        void ReciveData(String data)
        {
            this.richTextBox1.Text += "\n" + data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subcriable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_public_data form = new form_public_data();
            form.Show();
        }
    }
}
