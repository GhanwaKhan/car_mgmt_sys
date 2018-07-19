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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.button1.Visible=false;
            this.button2.Visible=false;
            this.button3.Visible=false;
            this.button4.Visible=false;
            this.button5.Visible=false;
            this.button6.Visible = false;
            this.button8.Visible=false;
            this.button9.Visible=false;
            this.button10.Visible=false;
            this.button11.Visible=false;
            this.button12.Visible = false;
            this.button18.Visible=false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.button1.Visible=true;
            this.button3.Visible=true;
            this.button4.Visible=true;
            this.button5.Visible=true;
            this.button18.Visible=true;
            this.button6.Visible = true;

            this.button8.Visible = false;
            this.button9.Visible = false;
            this.button10.Visible = false;
            this.button11.Visible = false;
            this.button12.Visible = false;
            this.button2.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.button8.Visible=true;
             this.button9.Visible=true;
             this.button10.Visible=true;
             this.button11.Visible=true;
             this.button12.Visible=true;
             this.button2.Visible=true;

             this.button1.Visible = false;
             this.button3.Visible = false;
             this.button4.Visible = false;
             this.button5.Visible = false;
             this.button18.Visible = false;
             this.button6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Show();
            this.Hide();
        }

     
    }
    }
