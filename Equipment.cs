using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Star_Fitness_center
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String equipment = textBox1.Text;
            String description = richTextBox1.Text;
            String mUsed = textBox2.Text;
            String dDate = dateTimePicker1.Text;

            // Safe numeric parsing to prevent application crash on invalid input
            Int64 cost;
            if (!Int64.TryParse(textBox3.Text, out cost))
            {
                MessageBox.Show("Please enter a valid numeric cost.");
                return;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ARIFMASUD\\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True;TrustServerCertificate=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // Corrected variable names and matched 4 columns to 4 values: EquipName, EDescription, Mused, Cost
            cmd.CommandText = "insert into Equipment(EquipName, EDescription, Mused,DDate, cost) values ('" + equipment + "','" + description + "','" + mUsed + "','" + dDate + "','" + cost + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Data saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
          
            textBox2.Clear();
            textBox3.Clear();
           

            dateTimePicker1.Value = DateTime.Now;
           
        }
    }
}
