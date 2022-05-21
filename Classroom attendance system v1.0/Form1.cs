using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Classroom_attendance_system_v1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=ClassroomDB;Integrated Security=True";

            //2. establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection
            con.Open();

            //4. prepare query
            string label2 = textBox1.Text;
            string label3 = textBox2.Text + textBox3.Text;
            string label4 = textBox4.Text;
            string label5 = textBox5.Text;
            string label6 = textBox6.Text;
            string label7 = textBox7.Text;

            string Query = "INSERT INTO Names VALUES ('" + label2 + "', '" + label3 + "', '" + label4 + "', '" + label5 + "', '"+ label6 +"', '"+ label7 +"')";

            //5. execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //6. close connection
            con.Close();

            MessageBox.Show(" Student Name: "  +textBox4.Text+ " " +textBox5.Text+ "\n Student ID: " +textBox1.Text+ "\n TIme: " +textBox2.Text+ ":" +textBox3.Text+ " " +comboBox1.Text+ "\n Year level & Section: " +textBox7.Text, "Attendace added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            textBox1.Focus();

            comboBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database (Connection String)
            String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=ClassroomDB;Integrated Security=True";

            //2. establish connection (c# sqlconnection class)
            SqlConnection con = new SqlConnection(ConnectionString);

            //3. open connection (c# sqlconnection open)
            con.Open();

            //4. prepare query
            string Query = "SELECT * FROM Names";
            SqlCommand cmd = new SqlCommand(Query, con);

            //5. execute query (c# sqlcommand class)
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["StudentID"], reader["time"], reader["FirstName"], reader["LastName"], reader["Yearlevel"], reader["Section"]);
            }

            //6. close connection (c# sqlcommand close)
            con.Close();
        }
    }
}
