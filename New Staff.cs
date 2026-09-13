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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Star_Fitness_center
{
    public partial class New_Staff : Form
    {
        public New_Staff()
        {
            InitializeComponent();
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
            Int64 mobile = Int64.Parse(textBox6.Text);
            String email = textBox4.Text;
            string joindate = dateTimePicker2.Text;
            String district = textBox3.Text; // Removed ()
            String division = textBox5.Text; // Removed ()
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ARIFMASUD\\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True;TrustServerCertificate=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Fixed SQL string concatenation syntax
            cmd.CommandText = "insert into New_Stafff(Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,District,Division) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + district + "','" + division + "')";

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
            textBox5.Clear();
            textBox6.Clear();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

        }
    }
}
