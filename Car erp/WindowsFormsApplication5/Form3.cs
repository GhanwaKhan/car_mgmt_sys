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
    public partial class Form3 : Form
    {
        Form1 conn = new Form1();
        public Form3()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.textBox11.ReadOnly = true;

            int c = 0;
            conn.sqlConnection1.Open();

            SqlCommand cmm = new SqlCommand("select count(VID) from Vendor", conn.sqlConnection1);
            SqlDataReader drr = cmm.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }
            textBox11.Text = "" + c.ToString();
            conn.sqlConnection1.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("insert into Vendor(VID, VName, VCode, VCity, PH1, PH2, VAddress,CPName,CPPH,CName,VStatus)values(@VID, @VName, @VCode, @VCity, @PH1,@PH2,@VAddress,@CPName,@CPPH, @CName, @VStatus);", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@VID", textBox11.Text);
            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox5.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox8.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            cmd.Parameters.AddWithValue("@CName", textBox10.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox7.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been inserted");
            conn.sqlConnection1.Close();


            conn.sqlConnection1.Open();
            SqlCommand cmm = new SqlCommand("select * from Vendor", conn.sqlConnection1);
            SqlDataReader dr = cmm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.sqlConnection1.Close();
        }
    }
}
