using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class OperatorPanelForm : Form
    {
        public OperatorPanelForm()
        {
            InitializeComponent();
        }

        private void BackFromOperatorPanelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
