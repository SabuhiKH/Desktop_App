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

namespace Desktop_Application
{
    public partial class USER_LOGIN : Form
    {

        public static string insertUser;

        public USER_LOGIN()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(DALC.GetConnectionString());


        private void button2_Click(object sender, EventArgs e)
        {
            ADD_USER user = new ADD_USER();
            user.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region LOGIN

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT COUNT(*) FROM USERS WHERE USERNAME ='" + textBox1.Text + "' and PASSWORD= '" + textBox2.Text + "' ",cn);

            //cmd.Parameters.AddWithValue("@user", textBox1.Text);
            //cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            SqlCommand cmd1 = new SqlCommand();
            cmd1 = new SqlCommand("SELECT * FROM USERS WHERE USERNAME ='"+textBox1.Text+ "' and PASSWORD= '"+textBox2.Text+"' ", cn);

            //cmd.Parameters.AddWithValue("@user",textBox1.Text);
            //cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            SqlDataReader dr = cmd1.ExecuteReader();



            if (cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }

            if (count>0 )
            {

                try
                {
                    while (dr.Read())
                    {

                        insertUser = dr["ID"].ToString();

                    }



                    USERS_LIST userList = new USERS_LIST();
                    userList.Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
            cn.Close();


            #endregion








        }
    }
}
