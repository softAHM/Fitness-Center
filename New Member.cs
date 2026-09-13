using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star_Fitness_center
{
    public partial class New_Member : Form
    {
        public New_Member()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            String lname = textBox2.Text;

            string gender = "";
            bool isChaked = radioButton1.Checked;
            if (isChaked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            String dob = dateTimePicker1.Text;
            Int64 mobile = Int64.Parse(textBox3.Text);
            String email = textBox4.Text;
            string joindate = dateTimePicker2.Text;
            string gymtime = comboBox1.Text;
            string adress = richTextBox1.Text;
            String membershiptime = comboBox2.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ARIFMASUD\\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True;TrustServerCertificate=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Corrected SQL mapping (10 columns to 10 values)
            cmd.CommandText = "insert into New_Member(Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Madress,MembershipTime) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + gymtime + "','" + adress + "','" + membershiptime + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Data saved");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            richTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;






        }
    }
}
