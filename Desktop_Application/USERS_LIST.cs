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
    public partial class USERS_LIST : Form
    {
        public USERS_LIST()
        {
            InitializeComponent();
        }

        //SqlConnection cn = new SqlConnection(DALC.GetConnectionString());



        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADD_USERS_INFO add = new ADD_USERS_INFO();

            add.Show();
            this.Hide();
            
         
        }


        public  void Fill()
        {

            #region Get_Data
            SqlConnection cn = new SqlConnection();
            cn = new SqlConnection(DALC.GetConnectionString());
            cn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("SELECT * FROM CONTACTS WHERE INSERT_USER = '" + USER_LOGIN.insertUser + "'", cn);

            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;

            cn.Close();

            #endregion

        }



        private void gETToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region Get_Data
            SqlConnection cn = new SqlConnection();
            cn = new SqlConnection(DALC.GetConnectionString());
            cn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("SELECT * FROM CONTACTS", cn);

            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            dataGridView1.DataSource = dt;

            cn.Close();

            #endregion
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* #region Get_Data
             SqlConnection cn = new SqlConnection();
             cn = new SqlConnection(DALC.GetConnectionString());
             cn.Open();

             SqlCommand cmd = new SqlCommand();

             cmd = new SqlCommand("SELECT * FROM CONTACTS", cn);

             if (cn.State == System.Data.ConnectionState.Closed)
             {
                 cn.Open();
             }

             SqlDataReader rdr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(rdr);

             dataGridView1.DataSource = dt;

             cn.Close();

             #endregion */
            Fill();


        }
        

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USER_INFO_UPDATE upd = new USER_INFO_UPDATE();
            DataGridView datagrid = new DataGridView();

            DialogResult dg = MessageBox.Show("Are you Sure ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dg==DialogResult.Yes)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(DALC.GetConnectionString());

                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    DataGridViewRow row = dataGridView1.CurrentRow;

                    upd.textBox1.Tag = row.Cells["ID"].Value.ToString();

                    cmd = new SqlCommand("DELETE FROM CONTACTS WHERE ID= @id", cn);

                    cmd.Parameters.AddWithValue("@id",upd.textBox1.Tag);
                    

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DELETED!!");

                    cn.Close();

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
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            USER_INFO_UPDATE upd = new USER_INFO_UPDATE();
            DataGridViewRow row = dataGridView1.CurrentRow;

            upd.textBox1.Tag = row.Cells["ID"].Value.ToString();

            upd.textBox1.Text = row.Cells["NAME"].Value.ToString();
            upd.textBox2.Text = row.Cells["SURNAME"].Value.ToString();
            upd.textBox3.Text = row.Cells["COMPANY"].Value.ToString();
            upd.textBox4.Text = row.Cells["COUNTRY_CODE"].Value.ToString();
            upd.textBox5.Text = row.Cells["PREFIX"].Value.ToString();
            upd.textBox6.Text = row.Cells["NUMBER"].Value.ToString();
            upd.textBox7.Text = row.Cells["INSERT_USER"].Value.ToString();

            upd.ShowDialog();
        }

        private void USERS_LIST_Load(object sender, EventArgs e)
        {
            Fill();
            //#region Get_Data
            //SqlConnection cn = new SqlConnection();
            //cn = new SqlConnection(DALC.GetConnectionString());
            //cn.Open();

            //SqlCommand cmd = new SqlCommand();

            //cmd = new SqlCommand("SELECT * FROM CONTACTS", cn);

            //if (cn.State == System.Data.ConnectionState.Closed)
            //{
            //    cn.Open();
            //}

            //SqlDataReader rdr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(rdr);

            //dataGridView1.DataSource = dt;

            //cn.Close();

            //#endregion
        }
    }
}
