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
    public partial class Form11 : Form
    {
        Form1 conn = new Form1();
        public Form11()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.textBox11.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();

            SqlCommand cmm = new SqlCommand("select count(CID) from Customer", conn.sqlConnection1);
            SqlDataReader drr = cmm.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }
            textBox11.Text = "0" + c.ToString();
            conn.sqlConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Customer(CID, CName, CAddress, CCity, PH1, PH2,CPName,CPPH,CEmail, CreditLimit,CStatus, CCompany)values(@CID, @CName, @CAddress, @CCity, @PH1, @PH2,@CPName,@CPPH,@CEmail, @CreditLimit,@CStatus, @CCompany);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@CID", textBox11.Text);
            cmd.Parameters.AddWithValue("@CName", textBox1.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox2.Text);
            cmd.Parameters.AddWithValue("@CCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox8.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            cmd.Parameters.AddWithValue("@CCompany", textBox10.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox7.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox12.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();


            conn.sqlConnection1.Open();
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
