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
    public partial class AdminPanelForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\My_Apps\\C#Corner\\CourseManagementSystem1\\CourseManagementSystem1\\CourseManagementDatabase1.mdf;Integrated Security=True";
        
        string tableName;
        string oldValue;
        string newValue;
        string columnName;
        int idPrimaryKey;

        public AdminPanelForm()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(950, 600);

            //department
            InsertDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
            UpdateDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
            DeleteDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //teacher
            TeacherInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
            TeacherUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
            TeacherDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //course
            CourseInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
            CourseUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
            CourseDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //CourseTabPageName.ForeColor = Color.Beige;
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseTable1CourseManagementDatabase1DataSet3.CourseTable1' table. You can move, or remove it, as needed.
            //this.courseTable1TableAdapter.Fill(this.courseTable1CourseManagementDatabase1DataSet3.CourseTable1);
            // TODO: This line of code loads data into the 'teacherTable1CourseManagementDatabase1DataSet2.TeacherTable1' table. You can move, or remove it, as needed.
            //this.teacherTable1TableAdapter.Fill(this.teacherTable1CourseManagementDatabase1DataSet2.TeacherTable1);
            // TODO: This line of code loads data into the 'courseManagementDatabase1DataSet.DepartmentTable1' table. You can move, or remove it, as needed.
            //this.departmentTable1TableAdapter.Fill(this.departmnetTable1CourseManagementDatabase1DataSet.DepartmentTable1);

            //System.Threading.Thread thrd = new System.Threading.Thread(new System.Threading.ThreadStart(LoadBackgroundImage));
            // thrd.Start();

            refreshGridView();
        }

        private void LoadBackgroundImage()
        {
            //tabPage1.BackgroundImage = global::CourseManagementSystem1.Properties.Resources.adpb;

        }

        private void AdminPanelForm_Resize(object sender, EventArgs e)
        {
            int size1 = ManageDataHeaderLabelName.Height;
            int size2 = (int)(size1 * .3);
            if (size2 > 0) ManageDataHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = (int)(size1 * .17);
            if (size3 > 0)
            {
                tabControl1.Font = new Font("Cambria", size3 + 1);
                tabControl3.Font = new Font("Cambria", size3 + 1);
            }

            int size5 = ManageDataHeaderLabelName.Height;
            int size4 = (int)(size5 * .17);
            if (size4 > 0)
            {

                //Depaetment
                DepartmentFullNameTextBoxName.AutoSize = false;
                DepartmentShortNameTextBoxName.AutoSize = false;
                DepartmentCodeTextBoxName.AutoSize = false;

                DepartmentFullNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                DepartmentShortNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                DepartmentCodeTextBoxName.Font = new Font("Cambria", size4 + 3);

                InsertDepartmentButtonName.Font = new Font("Cambria", size4 + 2);
                UpdateDepartmentButtonName.Font = new Font("Cambria", size4 + 2);
                DeleteDepartmentButtonName.Font = new Font("Cambria", size4 + 2);

                //Teacher
                TeacherNameTextBoxName.AutoSize = false;
                TeacherDepartmentComboBoxName.AutoSize = false;
                TeacherDepartmentComboBoxName.Padding = new Padding(13, 13, 3, 3);

                TeacherNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                TeacherDepartmentComboBoxName.Font = new Font("Cambria", size4 + 4);

                TeacherDeleteButtonName.Font = new Font("Cambria", size4 + 2);
                TeacherUpdateButtonName.Font = new Font("Cambria", size4 + 2);
                TeacherInsertButtonName.Font = new Font("Cambria", size4 + 2);

                //Course
                CourseNameTextBoxName.AutoSize = false;
                CourseCodeTextBoxName.AutoSize = false;
                CourseDepartmentComboBoxName.AutoSize = false;

                CourseNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                CourseCodeTextBoxName.Font = new Font("Cambria", size4 + 3);
                CourseDepartmentComboBoxName.Font = new Font("Cambria", size4 + 4);

                CourseInsertButtonName.Font = new Font("Cambria", size4 + 2);
                CourseUpdateButtonName.Font = new Font("Cambria", size4 + 2);
                CourseDeleteButtonName.Font = new Font("Cambria", size4 + 2);


                //DataTypeLabelName.Font = new Font("Cambria", size4 + 2);
                // DataTypeComboBox.Font = new Font("Cambria", size4 + 2);
                //tabControl1.Padding = new Point(, 12);
                //ManageDataHeaderLabelName.Text = tabControl1.Padding.ToString();

            }
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

        public void refreshGridView()
        {
           /* SqlConnection mSqlConnection = openConnection();
            DataTable mDataTable = new DataTable();
            DataTable mDataTable2 = new DataTable();
            DataTable mDataTable3 = new DataTable();

            //department
            string query = "select DepartmentFullName,DepartmentShortName,DepartmentCode,Id from DepartmentTable1";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            DepartmentDataGridView1.DataSource = mDataTable;

            //teacher
            string query2 = "select * from TeacherTable1";
            SqlCommand mSqlCommand2 = new SqlCommand(query2, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter2 = new SqlDataAdapter(mSqlCommand2);

            mSqlDataAdapter2.Fill(mDataTable2);
            TeacherDataGridView1.DataSource = mDataTable2;

            //course
            string query3 = "select * from CourseTable1";
            SqlCommand mSqlCommand3 = new SqlCommand(query3, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter3 = new SqlDataAdapter(mSqlCommand3);

            mSqlDataAdapter3.Fill(mDataTable3);
            TeacherDataGridView1.DataSource = mDataTable3;

            TeacherDepartmentComboBoxName.DataSource = mDataTable;
            TeacherDepartmentComboBoxName.DisplayMember = "DepartmentShortName";

            CourseDepartmentComboBoxName.DataSource = mDataTable;
            CourseDepartmentComboBoxName.DisplayMember = "DepartmentShortName";

            closeConnection(mSqlConnection);
            */
            
        }


        private void DepartmentTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);


        }

        private void TeacherTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);

        }

        private void CourseTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);

        }

        //department
        private void InsertDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void InsertDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void InsertDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void InsertDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void UpdateDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void UpdateDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void UpdateDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void UpdateDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void DeleteDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void DeleteDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void DeleteDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void DeleteDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.DarkCyan;
        }


        //Course
        private void CourseInsertButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseInsertButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseInsertButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.LightGray;
        }

        private void CourseInsertButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseUpdateButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseUpdateButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseUpdateButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.LightGray;
        }

        private void CourseUpdateButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseDeleteButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseDeleteButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseDeleteButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.LightGray;
        }

        private void CourseDeleteButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.DarkCyan;
        }


        //teacher
        private void TeacherInsertButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherInsertButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherInsertButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.LightGray;
        }

        private void TeacherInsertButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherUpdateButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherUpdateButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherUpdateButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.LightGray;
        }

        private void TeacherUpdateButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherDeleteButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherDeleteButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherDeleteButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.LightGray;
        }

        private void TeacherDeleteButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.DarkCyan;
        }

        int count = 0;
        private void DepartmentDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void CourseInsertButtonName_Click(object sender, EventArgs e)
        {

            ManageDataHeaderLabelName.Text = CourseDepartmentComboBoxName.SelectedItem.ToString();
        }

        private void DepartmentDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DepartmentDataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
               /* int columnIndex = columnIndex = DepartmentDataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = DepartmentDataGridView1.CurrentCell.RowIndex;

                string columnNameHere = DepartmentDataGridView1.Columns[columnIndex].HeaderText.ToString();
                string cellValue = DepartmentDataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int idHere = Int32.Parse(DepartmentDataGridView1.Rows[rowIndex].Cells[0].Value.ToString());

                ManageDataHeaderLabelName.Text = "ri=" + rowIndex + " / ci=" + columnIndex + " / cn=" + columnNameHere + " / id=" + idHere + " / cv=" + cellValue;

                tableName = "DepartmentTable";
                columnName = columnNameHere;
                oldValue = cellValue;
                idPrimaryKey = idHere;
                */
                

            }
            catch (Exception ex) { }

            //int promptValue = Prompt.ShowDialog("Test", "123");
        }

        private void UpdateDepartmentButtonName_Click(object sender, EventArgs e)
        {
            UpdateDataForm u = new UpdateDataForm(tableName,columnName,oldValue,idPrimaryKey);
            u.ShowDialog();
            refreshGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertDepartmentButtonName_Click(object sender, EventArgs e)
        {
            try
            {
              /*  string departmentFullName = DepartmentFullNameTextBoxName.Text;
                string departmentShortName = DepartmentShortNameTextBoxName.Text;
                string departmentCode = DepartmentCodeTextBoxName.Text;

                if (!String.IsNullOrEmpty(departmentFullName.Trim()) &&
                    !String.IsNullOrEmpty(departmentShortName.Trim()) &&
                    !String.IsNullOrEmpty(departmentCode.Trim()))
                {
                    SqlConnection mSqlConnection = openConnection();

                    //FIRING A COMMAND
                    string insertQuery = "insert into DepartmentTable1 (DepartmentFullName,DepartmentShortName,DepartmentCode)"
                                                        + "VALUES('" + departmentFullName +
                                                                "','" + departmentShortName +
                                                                "','" + departmentCode +
                                                                "')";

                    SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                    mSqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Department,  " + departmentFullName + " has been added succesfully");

                    closeConnection(mSqlConnection);

                    refreshGridView();
                    
                }
                else MessageBox.Show("Fill up all the fields");

                */
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fill up all the fields carefully");
            }
        }

        private void DeleteDepartmentButtonName_Click(object sender, EventArgs e)
        {
            try
            {
                /*

                if (idPrimaryKey>0 &&
                    !String.IsNullOrEmpty(columnName.Trim()) )
                {
                    SqlConnection mSqlConnection = openConnection();

                    //FIRING A COMMAND
                    /*string insertQuery = "insert into DepartmentTable1 (DepartmentFullName,DepartmentShortName,DepartmentCode)"
                                                        + "VALUES('" + departmentFullName +
                                                                "','" + departmentShortName +
                                                                "','" + departmentCode +
                                                                "')";

                    SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                    mSqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Department,  " + departmentFullName + " has been added succesfully");
                    
                    string query = "Delete from DepartmentTable1 where Id=" + idPrimaryKey;
                    SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                    mSqlCommand.ExecuteNonQuery();

                    //MessageBox.Show("Department,  " + DepartmentFullName + " has been added succesfully");

                    closeConnection(mSqlConnection);

                    refreshGridView();
                }
                else MessageBox.Show("Fill up all the fields");

                */

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fill up all the fields carefully");
            }
        }
    }

}

 


   
    

