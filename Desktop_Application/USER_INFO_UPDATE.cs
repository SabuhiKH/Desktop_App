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
    public partial class USER_INFO_UPDATE : Form
    {
        public USER_INFO_UPDATE()
        {
            InitializeComponent();
        }
        USERS_LIST user_list = new USERS_LIST();


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(DALC.GetConnectionString());
            DialogResult dg = MessageBox.Show("Are you Sure ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dg == DialogResult.Yes)
            {
                try
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd= new SqlCommand("UPDATE CONTACTS SET NAME=@name,SURNAME =@surname, COMPANY=@company, COUNTRY_CODE=@country_code, PREFIX=@prefix, NUMBER=@number, INSERT_USER=@insert_user WHERE ID=@id", cn);

                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@company", textBox3.Text);
                    cmd.Parameters.AddWithValue("@country_code", textBox4.Text);
                    cmd.Parameters.AddWithValue("@prefix", textBox5.Text);
                    cmd.Parameters.AddWithValue("@number", textBox6.Text);
                    cmd.Parameters.AddWithValue("@insert_user", textBox7.Text);

                    cmd.Parameters.AddWithValue("@id", textBox1.Tag);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("UPDATE IS SUCCESS !","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    user_list.Show();
                    this.Hide();

                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            else if (dg == DialogResult.No)
            {
                return;
            }
        }
    }
}
