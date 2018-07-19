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
    public partial class Form8 : Form
    {
        Form1 conn = new Form1();
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from GRNModel where GRNID = '" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox7.Text = dr["CModel"].ToString();
                textBox8.Text = dr["Qty"].ToString();
            }

            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Invoice(InvoiceID,VID,VName,InvoiceDate,Amount,GRNID,GRNDate,CPName,CPPH,DDate) values(@InvoiceID,@VID,@VName,@InvoiceDate,@Amount,@GRNID,@GRNDate,@CPName,@CPPH,@DDate)", conn.sqlConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VID", textBox5.Text);
            cmd.Parameters.AddWithValue("@VName", textBox6.Text);
            cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@GRNID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@GRNDate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@CPName", textBox10.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            cmd.Parameters.AddWithValue("@DDate", DateTime.Parse(dateTimePicker3.Text));
            cmd.ExecuteNonQuery();

            conn.sqlConnection1.Close();
            MessageBox.Show("Invoice has been created");

            conn.sqlConnection1.Open();
            SqlCommand cmm = new SqlCommand("select * from Invoice", conn.sqlConnection1);
            SqlDataReader dr = cmm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            int c = 0;

            conn.sqlConnection1.Open();
            SqlCommand cmmd = new SqlCommand("select count(InvoiceID) from Invoice ", conn.sqlConnection1);
            SqlDataReader drr = cmmd.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }

            textBox1.Text = "0" + c.ToString();
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select GRNID from GRN where Status='Open'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["GRNID"].ToString());
            }

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
