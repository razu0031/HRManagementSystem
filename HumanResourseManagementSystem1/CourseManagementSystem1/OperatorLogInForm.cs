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
    public partial class OperatorLogInForm : Form
    {
        public OperatorLogInForm()
        {
            InitializeComponent();
        }

        private void OperatorLogInForm_Resize(object sender, EventArgs e)
        {
            int size1 = AdminHeaderPanel.Height;
            int size2 = (int)(size1 * .25);
            if (size2 > 0) OperatorHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = OperatorLogInButtonName.Height;
            int size4 = (int)(size3 * .35);
            if (size4 > 0)
            {
                OperatorLogInButtonName.Font = new Font("Cambria", size4);


                OperatorUserNameTextBoxName.Font = new Font("Cambria", size4);
                OperatorPasswordTextBoxName.Font = new Font("Cambria", size4);

                OperatorUserNameTextBoxName.AutoSize = false;
                OperatorPasswordTextBoxName.AutoSize = false;
                //textBox1.Size = new Size(228, size4+5);
            }
        }

        private void OperatorLogInButtonName_Click(object sender, EventArgs e)
        {
            OperatorPanelForm operatorPanelFrom = new OperatorPanelForm();

            this.SetVisibleCore(false);
            operatorPanelFrom.ShowDialog();
            this.SetVisibleCore(true);
        }

        private void OparatorBackButtonName_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OparatorLogInTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.Menu,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, OperatorLogInFormPanel.Width, OperatorLogInFormPanel.Height, 10);

        }
    }
}
