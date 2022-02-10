using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Data.SqlClient;

namespace AssignmentW
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private IconButton curBtn;
        private Panel leftBorBtn;
        private Form curchildForm;

        //Connection DB
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GUO6OM8;Initial Catalog=Winform;Persist Security Info=True;User ID=sa;Password=sa");
        //Sql

        //Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorBtn = new Panel();
            leftBorBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }

        //
        private struct RGBcolor
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Method
        private void ActivateBtn(Object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableBtn();
                //Btn
                curBtn = (IconButton)senderBtn;
                curBtn.BackColor = Color.FromArgb(112, 124, 148);
                curBtn.ForeColor = color;
                curBtn.TextAlign = ContentAlignment.MiddleCenter;
                curBtn.IconColor = color;
                curBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                curBtn.ImageAlign = ContentAlignment.MiddleLeft;

                //Left Border Btn
                leftBorBtn.BackColor = color;
                leftBorBtn.Location = new Point(0, curBtn.Location.Y);
                leftBorBtn.Visible = true;
                leftBorBtn.BringToFront();

                //Label title
                iconPictureLabel.IconChar = curBtn.IconChar;
                iconPictureLabel.IconColor = color;
            }
        }

        //Disable Btn
        private void DisableBtn()
        {
            if(curBtn != null)
            {
                curBtn.BackColor = Color.FromArgb(112, 124, 148);
                curBtn.ForeColor = Color.White;
                curBtn.TextAlign = ContentAlignment.MiddleLeft;
                curBtn.IconColor = Color.White;
                curBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                curBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void openchilForm(Form childForm)
        {
            if (iconPictureLabel != null)
            {
                //Open only form
                curchildForm.Close();
            }
            curchildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        //Btn Study program
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color1);
            //openchilForm(new ());
        }

        //Btn Class
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color2);
        }

        //Btn Teacher
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color3);
        }

        //Btn Subject
        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color4);
        }

        //Btn Degree
        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color5);
        }

        //Btn Attendance
        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender, RGBcolor.color6);
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        //Btn logo
        private void iconButtonLogo_Click(object sender, EventArgs e)
        {
            //Close page
            curchildForm.Close();
            reset();
        }

        //resets
        private void reset()
        {
            DisableBtn();
            leftBorBtn.Visible = false;
            iconPictureLabel.IconChar = IconChar.Home;
            iconPictureLabel.IconColor = Color.White;
            labelTitle.Text = "Home";
        }

        //Drop & drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Btn Close
        private void iconButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Btn MaxSize
        private void iconButton9_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        //Btn MiniSize
        private void iconBtnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton7_Click_1(object sender, EventArgs e)
        {

        }
    }
}
