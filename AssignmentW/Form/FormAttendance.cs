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
    public partial class FormAttendance : Form
    {
        private SqlConnection sqlconn;
        String Class;
        String tea;
        String sub;
        String stu;
        String star;
        String end;
        String IDSC;
        String ClassDD;
        String subDD;
        String teaDD, IDAten, IDSubClass;

        public FormAttendance()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }
        void load()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM ClassSubject";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView2.DataSource = dt;
            sqlconn.Close();
        }
        void loadcombobx()
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
                    comboBoxclass.Items.Add(name);

                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void loadcombobxsub()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM Subject";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(1);
                    comboBoxsub.Items.Add(name);
                    comboBoxSubDD.Items.Add(name);
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadcombobxtea()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM Teacher";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(1);
                    comboBoxtea.Items.Add(name);
                    comboBoxteaDD.Items.Add(name);
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadcomboClass()
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
                    comboBoxClassDD.Items.Add(name);

                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadAt()
        {
            sqlconn.Open();
            string sql = " SELECT * FROM Attendance";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }
        private void buttoncreate_Click(object sender, EventArgs e)
        {
            String status1 = "0";
            if (checkBoxDd.Checked == true)
            {
                status1 = "1";
            }
            if (checkBoxKhoa.Checked == true)
            {
                status1 = "2";
            }
            DateTime iDatestar, dateend;
            iDatestar = dateTimePicker1.Value;
            dateend = dateTimePicker1.Value;
            star = iDatestar.ToString("dd/MM/yyyy");
            end = dateend.ToString("dd/MM/yyyy");
            try
            {

                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "INSERT INTO  ClassSubject ( StarDate, EndDate, TimeSlotClassSub, IDClass, Status, IDSub, IDTeacher) " +
                    "VALUES (@Star,@End, @Time, @IDClass, @Status,  @IDSub, @IDtea  )";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@End", end);
                sqlcmd.Parameters.AddWithValue("@Star", star);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxSlot.Text);
                sqlcmd.Parameters.AddWithValue("@IDClass", Class);
                sqlcmd.Parameters.AddWithValue("@IDSub", sub);
                sqlcmd.Parameters.AddWithValue("@Status", status1);
                sqlcmd.Parameters.AddWithValue("@IDtea", tea);
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
            String status1 = "0";
            if (checkBoxDd.Checked == true)
            {
                status1 = "1";
            }
            if (checkBoxKhoa.Checked == true)
            {
                status1 = "2";
            }
            DateTime iDatestar, dateend;
            iDatestar = dateTimePicker1.Value;
            dateend = dateTimePicker1.Value;
            star = iDatestar.ToString("dd/MM/yyyy");
            end = dateend.ToString("dd/MM/yyyy");
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "UPDATE ClassSubject set StarDate=@Star , EndDate=@End , TimeSlotClassSub=@Time, IDClass= @IDClass , Status= @Status , IDSub= @IDSub , IDTeacher= @IDtea where IDClassSubject= @ID ";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@ID", IDSC);
                sqlcmd.Parameters.AddWithValue("@End", end);
                sqlcmd.Parameters.AddWithValue("@Star", star);
                sqlcmd.Parameters.AddWithValue("@Time", textBoxSlot.Text);
                sqlcmd.Parameters.AddWithValue("@IDClass", Class);
                sqlcmd.Parameters.AddWithValue("@IDSub", sub);
                sqlcmd.Parameters.AddWithValue("@Status", status1);
                sqlcmd.Parameters.AddWithValue("@IDtea", tea);
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

        private void comboBoxclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Class where NameClass= '" + comboBoxclass.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(2);
                    textBoxSlot.Text = name;
                    string classid = myRead.GetString(0);
                    Class = classid;
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxsub_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql = " SELECT * FROM Subject where NameSub= '" + comboBoxsub.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetInt32(5).ToString();
                    string idsub = myRead.GetString(0);
                    sub = idsub;
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxtea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Teacher where NameTeacher= '" + comboBoxtea.Text + "';";
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
            sqlconn.Close();
        }


        private void comboBoxsem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "INSERT INTO Attendance (IDClassSubject, IDStudent) " +
                    "SELECT c.IDClassSubject,  s.IDStudent FROM ClassSubject c " +
                    "INNER JOIN  Student s ON c.IDClass = s.IDClass " +
                    "WHERE c.IDClass = @IDClass and c.IDSub = @IDSub";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@IDClass", ClassDD);
                sqlcmd.Parameters.AddWithValue("@IDSub", subDD);
                if (sqlcmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("The Subject is inserted to the database.");
                }
                else
                {
                    MessageBox.Show("aaaa");
                }

                sqlconn.Close();
                loadAt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inserting is failed.");
            }
        }

        
        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSubDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Subject where NameSub= '" + comboBoxSubDD.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {

                    string idsub = myRead.GetString(0);
                    subDD = idsub;
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxteaDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Teacher where NameTeacher= '" + comboBoxteaDD.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    string name = myRead.GetString(0);
                    teaDD = name;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlconn.Close();
        }
        private void comboBoxClassDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = " SELECT * FROM Class where NameClass= '" + comboBoxClassDD.Text + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader myRead;
            try
            {
                sqlconn.Open();
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {

                    string classid = myRead.GetString(0);
                    ClassDD = classid;

                }
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            IDSC = dataGridView2.Rows[numrow].Cells[0].Value.ToString();
            texthour.Text = dataGridView2.Rows[numrow].Cells[0].Value.ToString();
            textBoxSlot.Text = dataGridView2.Rows[numrow].Cells[3].Value.ToString();
            comboBoxclass.Text = dataGridView2.Rows[numrow].Cells[5].Value.ToString();
            comboBoxsub.Text = dataGridView2.Rows[numrow].Cells[6].Value.ToString();
            comboBoxtea.Text = dataGridView2.Rows[numrow].Cells[7].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            loadcombobx();
            loadcombobxsub();
            loadcombobxtea();
            load();
            loadcomboClass();
            loadAt();
        }
        private void buttoncreateDetail_Click(object sender, EventArgs e)
        {
            DateTime iDatestar ;
            string last;
            iDatestar = dateTimePicker2.Value;
            star = iDatestar.ToString("dd/MM/yyyy");
            last = DateTime.Now.ToString("dd/MM/yyyy");
            try
            {

                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "INSERT INTO AttendanceDetails (AttID, Status, Date, LastUpdate) " +
                    "SELECT a. AttID, '0', @Date, @Last " +
                    "FROM ClassSubject c INNER JOIN Attendance a ON c.IDClassSubject = a.IDClassSubject " +
                    "WHERE c.IDClass = @IDClass and c.IDSub = @IDSub";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@Date", star);
                sqlcmd.Parameters.AddWithValue("@Last", last);
                sqlcmd.Parameters.AddWithValue("@Status", star);
                sqlcmd.Parameters.AddWithValue("@IDClass", ClassDD);
                sqlcmd.Parameters.AddWithValue("@IDSub", subDD);

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

    }
}
