using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Form14 : Form
    {
        Form1 conn = new Form1();
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into SO(SOID, SODate, DDate, Status, Approve, CName, CaModel, CID,CPName,CPPH,Amount,CarReceived)values(@SOID, @SODate, @DDate, @Status, @Approve, @CName, @CaModel, @CID,@CPName,@CPPH,@Amount,@CarReceived);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
            cmd.Parameters.AddWithValue("@SODate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@DDate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@Status", textBox2.Text);
            cmd.Parameters.AddWithValue("@CName", textBox3.Text);
            cmd.Parameters.AddWithValue("@CaModel", textBox4.Text);
            cmd.Parameters.AddWithValue("@CID", textBox5.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox7.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox8.Text);
            cmd.Parameters.AddWithValue("@CarReceived", textBox9.Text);
            cmd.Parameters.AddWithValue("@Approve", textBox10.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();


            conn.sqlConnection1.Open();
            SqlCommand cmm = new SqlCommand("select * from SO", conn.sqlConnection1);
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
