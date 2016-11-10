using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication4
{
    public partial class NUEVO : Form
    {
        localhost.Service1 x = new localhost.Service1();

        public NUEVO()
        {
            InitializeComponent();
        }

        private void NUEVO_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            //String xm = x.Todo().GetXml().ToString();
            doc.LoadXml(x.Todo().GetXml().ToString());

            //XmlNodeList elem = doc.SelectNodes("/DataSet[@*]/Table");

            //XmlNode ex = elem[0].SelectSingleNode("Table");
            textBox2.Text = "";

            //textBox3.Text = x.Todo().GetXml().ToString();
            //textBox4.Text = x.Todo().GetXml().ElementAt(2).ToString();
            //this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

 
                String id = textBox1.Text;

                if (id == "1")
                {
                    textBox2.Text = "as125";
                    textBox3.Text = "ggf336";
                }
                else
                {
                    if (id == "12")
                    {
                        textBox2.Text = "msss";
                        textBox3.Text = "mlo222";
                    }
                    else
                    {
                        if (id == "125")
                        {
                            textBox2.Text = "lll";
                            textBox3.Text = "m";
                   
                        }
                    }
                }
           
        }


    }
}
