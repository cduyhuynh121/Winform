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

namespace AssignmentW
{
    public partial class FormStudent : Form
    {
        private SqlConnection sqlconn;

        public FormStudent()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }
        void load()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM TyeOfTeacher";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "INSERT INTO  TyeOfTeacher (IDTypeTeacher, NameTypeTeahcher) VALUES (@Name, @Type)";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@Name", textBoxNAme.Text);
                sqlcmd.Parameters.AddWithValue("@Type", textBoxType.Text);

                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("The StudyProgram is inserted to the database.");
                }

                sqlconn.Close();
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inserting is failed.");
            }
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "update TyeOfTeacher set  NameTypeTeahcher = @Type where IDTypeTeacher  = @ID";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@Type", textBoxType.Text);
                sqlcmd.Parameters.AddWithValue("@ID", textBoxNAme.Text);

                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("The Degree Type is update to the database.");
                sqlconn.Close();
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update is failed.");
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (textBoxNAme.Text != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee ? ", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.CommandText = "delete from TyeOfTeacher where IDTypeTeacher = @ID";
                        sqlcmd.Connection = sqlconn;
                        sqlcmd.Parameters.AddWithValue("@ID", textBoxNAme.Text);
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Succescly!");
                        sqlconn.Close();
                        load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Delete is failed.");
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxNAme.Text = "";
            textBoxType.Text = "";
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                string sql = " SELECT IDTypeTeacher , NameTypeTeahcher  FROM TyeOfTeacher where IDTypeTeacher = @Name OR NameTypeTeahcher = @Name ";
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                cmd.Parameters.AddWithValue("@Name", textBoxFind.Text);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                sqlconn.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Find is failed.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBoxNAme.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBoxType.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();

        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}

