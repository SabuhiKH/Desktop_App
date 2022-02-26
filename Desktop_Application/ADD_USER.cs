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
    public partial class ADD_USER : Form
    {
        public ADD_USER()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(DALC.GetConnectionString());



        bool isCheckedUser;
        public bool UsernameChecked()
        {
            isCheckedUser = false;
            SqlConnection cn = new SqlConnection(DALC.GetConnectionString());
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("SELECT * FROM USERS WHERE USERNAME =@user", cn);

            cmd.Parameters.AddWithValue("@user", textBox1.Text);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.HasRows == true)
                {
                    MessageBox.Show("Already exists username !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    isCheckedUser = true;
                }
            }
            cn.Close();
            return isCheckedUser;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool userChecked = UsernameChecked();
            if (userChecked)
            {

            }

            else
            {

                try
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();

                    cmd = new SqlCommand("INSERT INTO USERS VALUES(@user,@pass,@email)", cn);


                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);

                    //int scal = Convert.ToInt32(cmd.ExecuteScalar());

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Succesful!");

                        USER_LOGIN login = new USER_LOGIN();
                        login.Show();
                        this.Close();
                        cn.Close();
                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Error");
                }





            }
 




        }
    }
}
