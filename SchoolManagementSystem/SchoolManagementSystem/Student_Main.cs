using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Student_Main : Form
    {
        SELECT_DBClass s_dbc = new SELECT_DBClass();

        int targetLecName_Lecture_DBGrid;
        int student_num;

        public int TargetLecName_Lecture_DBGrid
        {
            set { targetLecName_Lecture_DBGrid = value; }
            get { return targetLecName_Lecture_DBGrid; }
        }

        public int Student_Num
        {
            set { student_num = value; }
            get { return student_num; }
        }

        public Student_Main(int student_code)
        {
            InitializeComponent();
            s_dbc.DB_Select_Mode_Open();
            Student_Num = student_code;
        }

        private void set_DBGrid_ColumnHearders()
        {
            dataGridView1.Columns["LEC_CODE"].HeaderText = "강의코드";
            dataGridView1.Columns["LEC_NAME"].HeaderText = "강의명";
            dataGridView1.Columns["LEC_CREDIT"].HeaderText = "학점";
            dataGridView1.Columns["LEC_ROOM"].HeaderText = "강의실";
            dataGridView1.Columns["LEC_CLASSIFY"].HeaderText = "강의구분";
        }

            private void set_Student_Info_Textbox()
        {
            s_dbc.CommandString = "SELECT STU_NUM, STU_NAME, STU_ADDR, STU_TEL, STU_CONDITION, STU_GRADE, PROF_NAME, DEPT_NAME, STU_BIRTH, STU_ADMISSION_DATE FROM STUDENT A, (SELECT * FROM DEPT, professor WHERE DEPT.DEPT_CODE = PROFESSOR.DEPT_CODE) B WHERE STU_NUM = " + Student_Num + "AND stu_main_prof = prof_num";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                txtNum.Text = s_dbc.DataReader[0].ToString();
                txtName.Text = s_dbc.DataReader[1].ToString();
                txtAddr.Text = s_dbc.DataReader[2].ToString();
                txtTel.Text = s_dbc.DataReader[3].ToString();
                txtCondition.Text = s_dbc.DataReader[4].ToString();
                txtGrade.Text = s_dbc.DataReader[5].ToString();
                txtMainProf.Text = s_dbc.DataReader[6].ToString();
                txtMajor.Text = s_dbc.DataReader[7].ToString();
                txtBirth.Text = string.Format("{0:yyyy/MM/dd}", s_dbc.DataReader[8]);
                txtAdmissionDate.Text = string.Format("{0:yyyy/MM/dd}", s_dbc.DataReader[9]);
            }
            s_dbc.DataReader.Close();
            s_dbc.MyConnection.Close();
        }

        private void show_Student_Lecture_Info()
        {
            s_dbc.CommandString = "Select LEC_NAME, LEC_CREDIT, LEC_ROOM, LEC_CLASSIFY, LEARNER_GRADE FROM LECTURE A, (SELECT * FROM STUDENT, lecture_learner WHERE student.stu_num = lecture_learner.stu_num and student.stu_num = " + Student_Num + ") B WHERE a.lec_code = B.LEC_CODE";


            s_dbc.DB_Select_By_DBAdaper("RefTable");
            s_dbc.Rows = s_dbc.RefTable.Rows;

            foreach (DataRow dr in s_dbc.Rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString());
                for (int i = 1; i < s_dbc.RefTable.Columns.Count; i++)
                {
                    item.SubItems.Add(dr[i].ToString());
                }
                listView1.Items.Add(item);
            }
        }

        private void show_Student_Lecture_Info_With_Search()
        {
            s_dbc.DB_Select_By_DBAdaper("RefTable");
            DataRow[] ResultRows = s_dbc.RefTable.Select("LEC_NAME like '%" + txtSearchLec.Text + "%'");
            listView1.Items.Clear();

            foreach (DataRow currRow in ResultRows)
            {
                ListViewItem item = new ListViewItem(currRow[0].ToString());
                for (int idx = 1; idx < s_dbc.RefTable.Columns.Count; idx++)
                {
                    item.SubItems.Add(currRow[idx].ToString());
                }
                listView1.Items.Add(item);
            }
        }

        private void set_Enrollment_Subject_DBGrid()
        {
            s_dbc.CommandString = "select LEC_CODE, LEC_NAME, LEC_CREDIT, LEC_ROOM, LEC_CLASSIFY from lecture S where s.lec_name NOT IN (select LEC_NAME from lecture a,  (SELECT LEC_CODE FROM STUDENT, LECTURE_LEARNER WHERE student.stu_num = lecture_learner.stu_num AND student.stu_num = " + Student_Num + ") b where a.lec_code = b.lec_code)";
            s_dbc.DB_Select_By_DBAdaper("RefTable");
            dataGridView1.DataSource = s_dbc.DS.Tables["RefTable"].DefaultView;
            TargetLecName_Lecture_DBGrid = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }

        private void Student_Main_Load(object sender, EventArgs e)
        {
            try
            {
                set_Student_Info_Textbox();
                show_Student_Lecture_Info();
                set_Enrollment_Subject_DBGrid();
                set_DBGrid_ColumnHearders();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    listView1.Items.Clear();
                    s_dbc.CommandString = "Select LEC_NAME, LEC_CREDIT, LEC_ROOM, LEC_CLASSIFY, LEARNER_GRADE FROM LECTURE A, (SELECT * FROM STUDENT, lecture_learner WHERE student.stu_num = lecture_learner.stu_num and student.stu_num =  " + Student_Num + ") B WHERE a.lec_code = B.LEC_CODE AND LEARNER_GRADE IS NOT NULL ORDER BY LEC_NAME ASC";
                }
                else
                {
                    listView1.Items.Clear();
                    s_dbc.CommandString = "Select LEC_NAME, LEC_CREDIT, LEC_ROOM, LEC_CLASSIFY, LEARNER_GRADE FROM LECTURE A,  (SELECT * FROM STUDENT, lecture_learner WHERE student.stu_num = lecture_learner.stu_num and student.stu_num = " + Student_Num + ") B  WHERE a.lec_code = B.LEC_CODE ORDER BY LEC_NAME ASC";
                }
                show_Student_Lecture_Info_With_Search();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchLec.Text != "")
                {
                    show_Student_Lecture_Info_With_Search();
                }
                else
                {
                    MessageBox.Show("빈칸을 입력하셨습니다.");
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                txtSearchLec.Text = "";

                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    show_Student_Lecture_Info();
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                else if (e.RowIndex > s_dbc.RefTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }
                TargetLecName_Lecture_DBGrid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    s_dbc.MyConnection.Open();
                    s_dbc.CommandString = "INSERT INTO Lecture_Learner (LEC_CODE, STU_NUM) VALUES(" + TargetLecName_Lecture_DBGrid + ",  " + Student_Num + ")";
                    s_dbc.MyCommand = new OracleCommand(s_dbc.CommandString, s_dbc.MyConnection);

                    //1차적으로 강의를 생성하는 부분
                    // 다대다 관계를 교수 - 교수강의 - 강의 테이블로 정규화를 시켜주었으므로
                    // 2차적으로 교수강의 테이블에 인스턴스를 추가하여 교수와 강의를 연결시켜주어야한다.

                    if (s_dbc.MyCommand.ExecuteNonQuery() > 0)
                    { // 강의가 성공적으로 생성되었으면

                        MessageBox.Show("수강신청에 성공하셨습니다.");
                        s_dbc.MyConnection.Close();
                    }
                    listView1.Items.Clear();
                    show_Student_Lecture_Info();
                    set_Enrollment_Subject_DBGrid();
                }
                else
                {
                    MessageBox.Show("수강 가능한 강의가 업습니다.");
                }
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
    }
}
