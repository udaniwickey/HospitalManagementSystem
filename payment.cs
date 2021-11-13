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

namespace Project
{
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtType.Text == "" || txtName.Text == "" || txtCharges.Text == "" || textTel.Text == "" || dateTimePicker1.Text == "" || textTel.Text==""||comboPaid.Text=="")
            {
                MessageBox.Show("Please Fill Items");
                return;
            }

            
            string query = "INSERT INTO Payment(type,p_name,t_no,charges,date,paid) VALUES('" + txtType.Text + "','" + txtName.Text + "','" + textTel.Text + "','" + txtCharges.Text + "','" + dateTimePicker1.Text + "','" + comboPaid.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment Done");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
                Console.ReadLine();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from Payment", con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtbl;
            }
            catch (SqlException)
            {
                MessageBox.Show("Error");
            }
            finally
            {


                con.Close();
                Console.ReadLine();
            }
        }
    }
}
