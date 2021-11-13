﻿using System;
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
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\chama\Downloads\c#\c# project\Final_assignment\project2\Project\Hospital.mdf;Integrated Security=True");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ( textName.Text == "" || textType.Text == "" || textBs.Text == "" || textOT.Text == "" || textBonus.Text == "" || textCharges.Text == "" || textFinal.Text == "")
            {
                MessageBox.Show("Please Fill Items");
                return;
            }

            
            string query = "INSERT INTO Esalary(name,type,basic_sal,over_time,bonus,charges,final_sal) VALUES('" + textName.Text + "','" + textType.Text + "','" + textBs.Text + "','" + textOT.Text + "','" + textBonus.Text + "','" + textCharges.Text + "','" + textFinal.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted Successfully");
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
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from Esalary", con);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                if (MessageBox.Show("Are you sure to Delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    string query = "DELETE FROM Esalary WHERE id = " + textID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successsfully Deleted");
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
            else
            {
                MessageBox.Show("Put ID to Continue");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
               

                

                string query = "UPDATE Esalary SET name = '" + textName.Text + "',type='" + textType.Text + "',basic_sal='" + textBs.Text + "',over_time='" + textOT.Text + "',charges='" + textCharges.Text + "',final_sal='" + textFinal.Text + "' WHERE id = " + textID.Text + "";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successsfully updated");
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
            else
            {
                MessageBox.Show("Put ID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textID.Text = "";
            textName.Text = "";
            textBonus.Text = "";
            textCharges.Text = "";
            textBs.Text = "";
            textType.Text = "";
            textFinal.Text = "";
            textOT.Text = "";
           
        }
    }
}
