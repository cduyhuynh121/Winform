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
    public partial class FormTeacher : Form
    {
        private SqlConnection sqlconn;
        
        public FormTeacher()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }
        void loaddivision()
        {
            sqlconn.Open();
            string sql = "  select * from Division";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            loaddivision();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
