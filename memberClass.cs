using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    class memberClass
    {
        public SqlConnection con;
        // SqlConnection con = new SqlConnection(@"Data Source=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Users\chama\Downloads\c#\c# project\Final_assignment\project2\Project\Hospital.mdf";Integrated Security=True;);
        public memberClass()
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\chama\Downloads\c#\c# project\Final_assignment\project2\Project\Hospital.mdf;Integrated Security = True";
            con = new SqlConnection(constring);
        }
    }

    class add : memberClass
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string contact { get; set; }

        
       
        public void Create_data()
        {
            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO Addmember(username, password, email, gender, co_no) VALUES(@username,@password,@email,@gender,@contact)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                    cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured");
                
            }
            finally
            {


                con.Close();
            }
            }

        }
    }

