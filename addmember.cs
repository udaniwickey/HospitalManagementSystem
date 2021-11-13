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
    public partial class addmember : Form
    {
        add add = new add();
        public addmember()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (textUname.Text == "" || textPass.Text == "" || textContact.Text == "" || textEmail.Text == "" || comboGender.Text == "")
           {
               MessageBox.Show("Please Fill Items");
               return;
           }

           if (!textEmail.Text.Contains("@"))
           {
               MessageBox.Show("Please Enter Valid Email");
               return;
           }

           if (textPass.Text.Length < 3)
           {
               MessageBox.Show("the Password length should be greater than or equal to 4");
               return;
           }
           /*

           SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
           string query = "INSERT INTO Addmember(username,password,email,gender,co_no) VALUES('" + textUname.Text + "','" + textPass.Text + "','" + textEmail.Text + "','" + comboGender.Text + "','" + textContact.Text + "')";
           SqlCommand cmd = new SqlCommand(query, con);
           try
           {
               con.Open();
               cmd.ExecuteNonQuery();
               MessageBox.Show("User Added Successfully");
           }
           catch (SqlException)
           {
               MessageBox.Show("Error");
           }
           finally
           {
               con.Close();
               Console.ReadLine();
           }*/
            adn();
        }
        public void adn()
        {
            add.username = textUname.Text;
            add.password = textPass.Text;
            add.email = textEmail.Text;
            add.gender = comboGender.Text;
            add.contact = textContact.Text;
            add.Create_data();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            textUname.Text = "";
            textPass.Text = "";
            textEmail.Text = "";
            comboGender.Text = "";
            textContact.Text = "";
            
        }
    }
}
