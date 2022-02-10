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
    public partial class FormSubject : Form
    {
        private SqlConnection sqlconn;
        public FormSubject()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());

        }
        void load()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM Subject";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;

        }
        void loadcombobox()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM StudyProgram";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(1);
                    comboBox1.Items.Add(name);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "INSERT INTO  Subject (IDSub, NameSub, TimeSlotSub, Sem, IDPro) VALUES (@ID, @Name, @Time, @Sem, @IDPro)";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", textBoxId.Text);
                sqlcmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxTime.Text);
                sqlcmd.Parameters.AddWithValue("@Sem", textBoxSem.Text);
                sqlcmd.Parameters.AddWithValue("@IDPro", textBoxIDPRo.Text);
                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("The Subject is inserted to the database.");
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
                sqlcmd.CommandText = "update Subject set   NameSub = @Name, TimeSlotSub=@Time, Sem=@Sem ,IDPro= @IDPro  where IDSub = @ID";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", textBoxId.Text);
                sqlcmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxTime.Text);
                sqlcmd.Parameters.AddWithValue("@Sem", textBoxSem.Text);
                sqlcmd.Parameters.AddWithValue("@IDPro", textBoxIDPRo.Text);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("The Subject is update to the database.");
                sqlconn.Close();
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update is failed.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
            string sql = " SELECT * FROM StudyProgram where NamePro= '" + comboBox1.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetInt32(0).ToString();
                    textBoxIDPRo.Text = name;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBoxId.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBoxTime.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            textBoxSem.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            textBoxIDPRo.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            textBoxId.Enabled = false;

        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text != string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this employee ? ", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                        sqlconn.Open();
                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.CommandText = "delete from Subject where IDSub = @ID";
                        sqlcmd.Connection = sqlconn;
                        sqlcmd.Parameters.AddWithValue("@ID", textBoxId.Text);
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
            textBoxName.Text = string.Empty;
            textBoxId.Text = string.Empty;
            textBoxIDPRo.Text = string.Empty;
            textBoxSem.Text = string.Empty;
            textBoxTime.Text = string.Empty;

        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                string sql = " SELECT NameSub, TimeSlotSub,Sem  from Subject where NameSub = @Name OR TimeSlotSub= @Name OR Sem= @Name ";
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

        private void FormSubject_Load(object sender, EventArgs e)
        {
            load();
            loadcombobox();
        }
    }
}

