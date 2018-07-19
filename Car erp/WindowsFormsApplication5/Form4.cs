using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    public partial class Form4 : Form
    {
        Form1 conn = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select CName from Company", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CName"].ToString());
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Company where CName='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox5.Text = dr["CID"].ToString();
                textBox16.Text = dr["Assembly"].ToString();
            }
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmm = new SqlCommand("select CaModel from Model where CName='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader drr = cmm.ExecuteReader();
            this.comboBox2.Items.Clear();
            while (drr.Read())
            {
                comboBox2.Items.Add(drr["CaModel"].ToString());
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Model where CaModel='" + comboBox2.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["CaID"].ToString();
                textBox3.Text = dr["Price"].ToString();
                textBox4.Text = dr["DeliveryDays"].ToString();
                textBox6.Text = dr["Colour"].ToString();
                textBox7.Text = dr["Speed"].ToString();
                textBox8.Text = dr["Used/New"].ToString();
                textBox9.Text = dr["Transmission"].ToString();
                textBox10.Text = dr["Seaters"].ToString();
                textBox11.Text = dr["Year"].ToString();
                textBox12.Text = dr["EType"].ToString();
                textBox13.Text = dr["RegIn"].ToString();
                textBox14.Text = dr["Mileage"].ToString();
                textBox15.Text = dr["RegCity"].ToString();
            }
            conn.sqlConnection1.Close();
        }
    }
}
