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
    public partial class Form7 : Form
    {
        Form1 conn = new Form1();
        public Form7()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();

            SqlCommand cmm = new SqlCommand("select count(GRNID) from GRN", conn.sqlConnection1);
            SqlDataReader drr = cmm.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }
            textBox1.Text = "G00" + c.ToString();
            conn.sqlConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into GRN(GRNID, POID, Status, CName, DDate, GRNDate)values(@GRNID, @POID, @Status, @CName, @DDate, @GRNDate);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@GRNID", textBox1.Text);
            cmd.Parameters.AddWithValue("@POID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Status", textBox3.Text);
            cmd.Parameters.AddWithValue("@CName", textBox4.Text);
            cmd.Parameters.AddWithValue("@DDate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@GRNDate", DateTime.Parse(dateTimePicker2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();


            conn.sqlConnection1.Open();
            SqlCommand cmm = new SqlCommand("select * from GRN", conn.sqlConnection1);
            SqlDataReader dr = cmm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }
    }
}
