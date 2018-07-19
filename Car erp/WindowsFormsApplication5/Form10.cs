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
    public partial class Form10 : Form
    {
        Form1 conn = new Form1();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select CID from Customer where CStatus='open'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"].ToString());
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from Customer where CID='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["CName"].ToString();
                textBox2.Text = dr["CAddress"].ToString();
                textBox3.Text = dr["CCity"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox8.Text = dr["CPName"].ToString();
                textBox9.Text = dr["CPPH"].ToString();
                textBox13.Text =dr["CEmail"].ToString();
                textBox12.Text=dr["CreditLimit"].ToString();
                textBox7.Text = dr["CStatus"].ToString();
                textBox10.Text = dr["CCompany"].ToString();
                

            }
            conn.sqlConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("update Customer set CStatus='close' where CID='" + comboBox1.Text + "'", conn.sqlConnection1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");

            SqlCommand cmm = new SqlCommand("select * from Customer", conn.sqlConnection1);
            SqlDataReader dr = cmm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();

            this.Hide();
        }
    }
}
