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
    public partial class Form15 : Form
    {
        string[] prds = new string[50];
        int[] qty = new int[50];
        int counter = 0;

        Form1 conn = new Form1();
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();

            SqlCommand cmd = new SqlCommand("Select CName from company", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CName"]).ToString();
            }
            conn.sqlConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(SOID) from SO", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            {
                    if (dr.Read())
                    {
                        c = Convert.ToInt32(dr[0]);
                        c++;
                    }

                    if (comboBox1.Text == "Toyota")
                    {
                        textBox1.Text = "Toy0" + c.ToString();
                    }
                    else if (comboBox1.Text == "Mercedees")
                    {
                        this.textBox1.Text = "Mer0" + c.ToString();
                    }
                    else if (comboBox1.Text == "Honda")
                    {
                        this.textBox1.Text = "Hon0" + c.ToString();
                    }
                    else if (comboBox1.Text == "DewanMotor")
                    {
                        this.textBox1.Text = "Dew0" + c.ToString();
                    }
                    else if (comboBox1.Text == "BMW")
                    {
                        this.textBox1.Text = "BMW0" + c.ToString();
                    }
                    else if (comboBox1.Text == "Audi")
                    {
                        this.textBox1.Text = "Aud0" + c.ToString();
                    }
                    else if (comboBox1.Text == "FawMotor")
                    {
                        this.textBox1.Text = "Faw0" + c.ToString();
                    }
                    else if (comboBox1.Text == "Ferrari")
                    {
                        this.textBox1.Text = "Fer0" + c.ToString();
                    }
                    else
                    {
                        this.textBox1.Text = "Dai-00" + c.ToString();
                    }
                }
                conn.sqlConnection1.Close();

                conn.sqlConnection1.Open();
                SqlCommand cmm = new SqlCommand("select CaID from Model where CName='" + comboBox1.Text + "'", conn.sqlConnection1);
                SqlDataReader drr = cmm.ExecuteReader();
                this.comboBox2.Items.Clear();
                while (drr.Read())
                {
                    comboBox2.Items.Add(drr["CaID"].ToString());
                }
                conn.sqlConnection1.Close();

            }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text += comboBox2.Text + Environment.NewLine;
            textBox5.Text += textBox3.Text + Environment.NewLine;
            prds[counter] = comboBox2.Text;
            qty[counter] = Convert.ToInt32(textBox3.Text);
            counter++;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            for (int i = 0; i < counter; i++)
            {
                SqlCommand cmd = new SqlCommand("insert into SOModel (SOID,CaID,Qty) values(@SOID,@CaID,@Qty)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
                cmd.Parameters.AddWithValue("@CaID", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Qty", textBox3.Text);
                cmd.ExecuteNonQuery();
            }
            conn.sqlConnection1.Close();
            MessageBox.Show("Transaction has been done");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = "1";
            this.textBox3.ReadOnly = true;

            conn.sqlConnection1.Open();
            SqlCommand cmmd = new SqlCommand("select * from Model where CaID='" + comboBox2.Text + "'", conn.sqlConnection1);
            SqlDataReader drr = cmmd.ExecuteReader();

            if (drr.Read())
            {
                textBox2.Text = drr["CaModel"].ToString();
            }
            conn.sqlConnection1.Close();
        }
    }
}
