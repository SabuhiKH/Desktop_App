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

namespace Desktop_Application
{
    public partial class ADD_USERS_INFO : Form
    {
        public ADD_USERS_INFO()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(DALC.GetConnectionString());


        public void ClearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dg = MessageBox.Show("Are you Sure ?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question);


            if (dg ==DialogResult.Yes)
            {


                try
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();

                    cmd = new SqlCommand("INSERT INTO CONTACTS (NAME,SURNAME,COMPANY,COUNTRY_CODE,PREFIX,NUMBER,INSERT_USER) VALUES(@name,@surname,@company,@country_code,@prefix,@number,@insert_user)", cn);

                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@company", textBox3.Text);
                    cmd.Parameters.AddWithValue("@country_code", textBox4.Text);
                    cmd.Parameters.AddWithValue("@prefix", textBox5.Text);
                    cmd.Parameters.AddWithValue("@number", textBox6.Text);
                    cmd.Parameters.AddWithValue("@insert_user", USER_LOGIN.insertUser);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    cmd.ExecuteNonQuery();
                    ClearText();
                    MessageBox.Show("SUCCESFUL!","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    USERS_LIST user_list = new USERS_LIST();
                    user_list.Show();
                    this.Hide();
                    


                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }


            else if (dg==DialogResult.No)
            {
                return;
            }

        }
    }
}
