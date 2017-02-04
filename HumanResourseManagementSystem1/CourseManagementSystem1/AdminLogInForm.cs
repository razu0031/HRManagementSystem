using Plasmoid.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class AdminLogInForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public AdminLogInForm()
        {
            InitializeComponent();

            LogInButtonName.BackColor= Color.FromArgb(0, 200, 200);         
            BackButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 20, 20));
            //Graphics g = new Graphics(;

        }

        private void AdminPanelForm_Resize(object sender, EventArgs e)
        {
            int size1 = AdminHeaderPanel.Height;
            int size2 = (int)(size1 * .25);
            if (size2 > 0) AdminHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = LogInButtonName.Height;
            int size4 = (int)(size3 * .35);
            if (size4 > 0)
            {
                LogInButtonName.Font = new Font("Cambria", size4);
                

                textBox1.Font= new Font("Cambria", size4);
                textBox2.Font = new Font("Cambria", size4);

                textBox1.AutoSize = false;
                textBox2.AutoSize = false;
                //textBox1.Size = new Size(228, size4+5);
            }
        }


        private void LogInButtonName_Click(object sender, EventArgs e)
        {
            AdminPanelForm adminPanelFrom = new AdminPanelForm();

            this.SetVisibleCore(false);
            adminPanelFrom.ShowDialog();
            this.SetVisibleCore(true);
        }

        private void BackButtonName_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.Menu,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, AdminLogInFormPanel.Width, AdminLogInFormPanel.Height, 10);
           
        }

        private void LogInButtonName_MouseEnter(object sender, EventArgs e)
        {
            LogInButtonName.BackColor = Color.DarkCyan;
        }

        private void LogInButtonName_MouseLeave(object sender, EventArgs e)
        {
            LogInButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void LogInButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            LogInButtonName.BackColor = Color.LightGray;
        }

        private void LogInButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            LogInButtonName.BackColor = Color.DarkCyan;
        }

        private void BackButtonName_MouseEnter(object sender, EventArgs e)
        {
            BackButtonName.BackColor = Color.DarkCyan;
        }

        private void BackButtonName_MouseLeave(object sender, EventArgs e)
        {
            BackButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void BackButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            BackButtonName.BackColor = Color.LightGray;
        }

        private void BackButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            BackButtonName.BackColor = Color.DarkCyan;
        }

        
    }
}
