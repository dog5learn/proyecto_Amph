using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class BUSCAR : Form
    {
        public BUSCAR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("id no puede ser nulo");
                return;
            }
            else
            {
                Regex val = new Regex(@"^[+-]?\d+(\.\d+)?$");
                if (val.IsMatch(textBox1.Text))
                {
                    String id = textBox1.Text;
                    localhost.Service1 x = new localhost.Service1();
                    x.Borra_uno(id);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("caracter invalido");
                    textBox1.Clear();
                    return;
                }

            }
            this.Close();
        }
    }
}
