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
    public partial class Ministry : Form
    {
        private SqlConnection sqlconn;
        String tea, degree, id;
        public Ministry()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }

        void loadsubject()
        {
            sqlconn.Open();
            string sql = "  select * from Subject";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView2.DataSource = dt;
            sqlconn.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            id = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            tea = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            degree = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            comboBox1.Text = tea;
            comboBox2.Text = degree;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        void load1()
        {
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
            sqlconn.Open();
            string sql = "  select dt.IDDeOfTea, t.NameTeacher, d.DegreeName from Teacher t inner join DegreeOfTeacher dt  on t.IDTeacher = dt.IDTeacher inner join Degree d on d.IDDegree = dt.IDDegree";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }
        void comboboxtea()
        {
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
            sqlconn.Open();
            string sql = " SELECT * FROM Teacher  ";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            //cmd.Parameters.AddWithValue("@IDtea", tea);
            SqlDataReader myRead;
            try
            {
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(1);
                    comboBox1.Items.Add(name);

                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "update DegreeOfTeacher set IDTeacher= @tea , IDDegree=@degree " +
                    "where IDDeOfTea= @ID ";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", id);
                sqlcmd.Parameters.AddWithValue("@tea", tea);
                sqlcmd.Parameters.AddWithValue("@degree", degree);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("The Subject is update to the database.");
                sqlconn.Close();
                load1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update is failed.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Teacher where NameTeacher= '" + comboBox1.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(0);
                    tea = name;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Degree where DegreeName= '" + comboBox2.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(0);
                    degree = name;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        void comboboxdegree()
        {
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
            sqlconn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = "SELECT * FROM Degree";
            sqlcmd.Connection = sqlconn;
            //sqlcmd.Parameters.AddWithValue("@ID", degree);
            SqlDataReader myRead;
            try
            {
                myRead = sqlcmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(1);
                    comboBox2.Items.Add(name);

                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("loioo");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboboxdegree();
            comboboxtea();
            load1();

        }
    }
}