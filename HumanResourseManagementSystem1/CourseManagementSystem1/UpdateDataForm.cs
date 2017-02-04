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
using System.Data.SqlClient;

namespace CourseManagementSystem1
{
    public partial class UpdateDataForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\My_Apps\\C#Corner\\CourseManagementSystem1\\CourseManagementSystem1\\CourseManagementDatabase1.mdf;Integrated Security=True";

        string tableName;
        string oldValue;
        string newValue;
        string columnName;
        int idPrimaryKey;

        public UpdateDataForm()
        {
            InitializeComponent();

            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox1.Font = new Font("Cambria", 12);
            textBox2.Font = new Font("Cambria", 12);

            CancelButton.Font = new Font("Cambria", 12);
            UpdateButton.Font = new Font("Cambria", 12);
        }

        public UpdateDataForm(String tableNameHere, String columnNameHere, String oldValueHere, int idHere)
        {
            InitializeComponent();

            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox1.Font = new Font("Cambria", 12);
            textBox2.Font = new Font("Cambria", 12);

            CancelButton.Font = new Font("Cambria", 12);
            UpdateButton.Font = new Font("Cambria", 12);

            UpdateFormHeaderLabelName.Text = tableNameHere + " Update";
            textBox1.Text = oldValueHere;

            tableName=tableNameHere;
            oldValue=oldValueHere;
            columnName=columnNameHere;
            idPrimaryKey=idHere;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, panel2.Width, panel2.Height, 10);

        }

        public SqlConnection openConnection()
        {
            SqlConnection mSqlConnection = new SqlConnection(connectionString);
            mSqlConnection.Open();

            Button n = new Button();
            n.Visible = true;

            return mSqlConnection;

        }

        public void closeConnection(SqlConnection mSqlConnection)
        {
            mSqlConnection.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                newValue = textBox2.Text;
                
                if (!String.IsNullOrEmpty(newValue.Trim()))
                {
                    try
                    {
                        SqlConnection mSqlConnection = openConnection();

                        string query = "update DepartmentTable1 set " + columnName + "='" + newValue + "' where Id=" + idPrimaryKey;
                        SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                        mSqlCommand.ExecuteNonQuery();

                        closeConnection(mSqlConnection);

                        MessageBox.Show("Row " + idPrimaryKey + "  has updated succesfully from\n" + oldValue + "  to  " + newValue);

                        this.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
                    }
                }
                else MessageBox.Show("Fill up the New Value Fields");

            }
            catch (Exception)
            {
                MessageBox.Show("Fill up the New Value Fields");
            }

        }

    }
    
}
