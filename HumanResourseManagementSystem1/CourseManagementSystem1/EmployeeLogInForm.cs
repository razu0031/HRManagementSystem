using Plasmoid.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class EmployeeLogInForm : Form
    {
        public EmployeeLogInForm()
        {
            InitializeComponent();
        }

        private void EmployeeLogInFormPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.Menu,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, EmployeeLogInFormPanel.Width, EmployeeLogInFormPanel.Height, 10);

        }

        private void EmployeeLogInForm_Resize(object sender, EventArgs e)
        {
            int size1 = AdminHeaderPanel.Height;
            int size2 = (int)(size1 * .25);
            if (size2 > 0) EmployeeHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = EmployeeLogInButtonName.Height;
            int size4 = (int)(size3 * .35);
            if (size4 > 0)
            {
                EmployeeLogInButtonName.Font = new Font("Cambria", size4);


                EmployeeUserNameTextBoxName.Font = new Font("Cambria", size4);
                EmployeePasswordTextBoxName.Font = new Font("Cambria", size4);

                EmployeeUserNameTextBoxName.AutoSize = false;
                EmployeePasswordTextBoxName.AutoSize = false;
                //textBox1.Size = new Size(228, size4+5);
            }
        }

        private void EmployeeLogInButtonName_Click(object sender, EventArgs e)
        {
            EmployeePanelForm employeePanelFrom = new EmployeePanelForm();

            this.SetVisibleCore(false);
            employeePanelFrom.ShowDialog();
            this.SetVisibleCore(true);
        }

        private void EmployeeBackButtonName_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
