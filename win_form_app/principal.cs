using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.CenterToParent();

        }
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            AddPanel(new NUEVO());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPanel(new BUSCAR());

        }

        private void AddPanel(object formHijo)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        } 

    }
}
