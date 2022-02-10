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
    public partial class FormClass : Form
    {
        private SqlConnection sqlconn;
        string IDStudy;
        public FormClass()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }
        void load()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM Class";
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
            string sql = " SELECT * FROM Class";
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
                sqlcmd.CommandText = "INSERT INTO  Class (IDClass, NameClass, TimeSlotClass, IDPro) VALUES (@ID, @Name, @Time, @IDPro)";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", textBoxId.Text);
                sqlcmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxTime.Text);
                sqlcmd.Parameters.AddWithValue("@IDPro", IDStudy);
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
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "UPDATE  Class set NameClass = @Name, TimeSlotClass=@Time ,IDPro= @IDPro  where IDClass = @ID";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", textBoxId.Text);
                sqlcmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxTime.Text);
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
                        sqlcmd.CommandText = "delete from Class where IDClass = @ID";
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
            textBoxTime.Text = string.Empty;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBoxId.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBoxName.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBoxTime.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            textBoxIDPRo.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            textBoxId.Enabled = false;
        }


        private void buttonsearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                string sql = " SELECT NameClass, TimeSlotClass  from Class where NameClass = @Name OR TimeSlotClass= @Name ";
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
                    IDStudy = name;
                    textBoxIDPRo.Text = IDStudy;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormClass_Load(object sender, EventArgs e)
        {
            load();
            loadcombobox();
        }
    }
}
