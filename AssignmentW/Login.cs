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
    public partial class Login : Form
    {
        private SqlConnection sqlconn;
        public Login()
        {
            InitializeComponent();
            sqlconn = new SqlConnection(Properties.Settings.Default.DB.ToString());
        }

        public static string ID_USER = "";

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username is not blank");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password is not blank");
                txtPassword.Focus();
                return;
            }
            if (sqlconn.State == ConnectionState.Closed)
            {
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "SELECT * FROM Login WHERE Username = @Username AND Password = @Password ";
                sqlcmd.Connection = sqlconn;
                sqlcmd.Parameters.AddWithValue("@Username", txtUsername.Text.ToString().Trim());
                sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString().Trim());
                SqlDataReader sqlLogin = sqlcmd.ExecuteReader();
                if (sqlLogin.HasRows)
                {
                    ID_USER = txtUsername.Text;
                    MessageBox.Show("Login Success!", "OK", MessageBoxButtons.OK);

                    FormMainMenu f1 = new FormMainMenu();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlconn.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
