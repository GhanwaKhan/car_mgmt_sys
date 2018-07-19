using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "cars" && this.textBox2.Text=="1234")
            {
                Form9 f9 = new Form9();
                f9.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your ID or password is incorrect");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
