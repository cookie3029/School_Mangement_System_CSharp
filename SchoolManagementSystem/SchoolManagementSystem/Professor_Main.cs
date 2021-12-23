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
    public partial class Professor_Main : Form
    {
        SELECT_DBClass s_dbc = new SELECT_DBClass(); //쿼리문에 따라 해당 테이블을 조회하는 클래스
        STUDENT_CUD_DBClass stu_cud_dbc = new STUDENT_CUD_DBClass(); //학생 테이블을 대상으로 생성, 수정, 삭제,  작성을 수행하기 위한 클래스

        private string searchText;
        private string targetStuNum_Student_DBGrid;
        private int professor_code;
        private int kindOfSearch_Student;

        public int Professor_Code
        {
            get { return professor_code; }
            set { professor_code = value; }
        }

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value.ToString(); }
        }

        public string TargetStuNum_Student_DBGrid
        {
            get { return targetStuNum_Student_DBGrid; }
            set { targetStuNum_Student_DBGrid = value.ToString(); }
        }

        public Professor_Main(int _professor_code)
        {
            InitializeComponent();

            Professor_Code = _professor_code;

            s_dbc.DB_Select_Mode_Open();
            stu_cud_dbc.DB_CUD_Mode_Open();
        }

        private void showProfessorInfo()
        {
            s_dbc.CommandString = "SELECT PROF_NUM, PROF_NAME, PROF_OFFICE, PROF_TEL, DEPT_NAME, PROF_BIRTH, PROF_ADDRESS  FROM PROFESSOR, DEPT WHERE professor.dept_code = dept.dept_code and professor.PROF_NUM = '" + professor_code + "'";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                txtNum.Text = s_dbc.DataReader[0].ToString();
                txtName.Text = s_dbc.DataReader[1].ToString();
                txtOffice.Text = s_dbc.DataReader[2].ToString();
                txtTel.Text = s_dbc.DataReader[3].ToString();
                txtDept.Text = s_dbc.DataReader[4].ToString();
                txtBirth.Text = string.Format("{0:yyyy/MM/dd}", s_dbc.DataReader[5]);
                txtAddr.Text = s_dbc.DataReader[6].ToString();
            }
            s_dbc.MyConnection.Close();
        }

        private void showProfessorLecture()
        {
            s_dbc.CommandString = "Select A.LEC_NAME, A.LEC_CREDIT, A.LEC_ROOM FROM LECTURE A, (SELECT * FROM Professor, lecture_teach WHERE professor.prof_num = lecture_teach.prof_num and professor.prof_num = '" + professor_code + "') B WHERE a.lec_code = B.LEC_CODE";
            s_dbc.DB_Select_By_DBAdaper("MY_LEC_TABLE");
            LectureDBGrid.DataSource = s_dbc.DS.Tables["MY_LEC_TABLE"].DefaultView;
        }

        private void showProfessorStudent()
        {
            s_dbc.CommandString = "SELECT stu_num, stu_name, stu_grade, stu_tel, stu_addr, stu_admission_date, stu_birth  FROM STUDENT WHERE stu_main_prof = '" + professor_code + "' ORDER BY stu_num asc";
            s_dbc.DB_Select_By_DBAdaper("MY_STUDENT_TABLE");

            MyStudentList.DataSource = s_dbc.DS.Tables["MY_STUDENT_TABLE"].DefaultView;

            TargetStuNum_Student_DBGrid = MyStudentList.Rows[0].Cells[0].Value.ToString();
        }

        private void createStudent()
        {
            Student_Info_Input dlg = new Student_Info_Input();

            Set_Student_Info_Input_Form(dlg);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("학생을 추가합니다.");
                stu_cud_dbc.DB_Create_At_StudentTBL(dlg.Stu_Num, dlg.Stu_Name, dlg.Stu_Grade, dlg.Stu_Condition, dlg.Stu_Addr, dlg.Stu_Tel, dlg.Stu_Major, dlg.Stu_Main_Prof, dlg.Stu_Birth, dlg.Stu_Admission_Date);
                showProfessorStudent();
            }
            dlg.Dispose();
        }

        private void modifyStudent()
        {
            Student_Info_Change dlg = new Student_Info_Change();

            Set_Student_Info_Change_Form(dlg);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("선택한 학생을 수정합니다.");
                stu_cud_dbc.SelectedKeyValue = TargetStuNum_Student_DBGrid;
                stu_cud_dbc.DB_Update_At_StudentTBL(dlg.Stu_Addr, dlg.Stu_Tel, dlg.Stu_Condition);
                showProfessorStudent();
            }
            dlg.Dispose();
        }

        private void deleteStudent()
        {
            MessageBox.Show("선택한 학생을 삭제합니다.");
            stu_cud_dbc.SelectedKeyValue = TargetStuNum_Student_DBGrid;
            stu_cud_dbc.DB_Delete_At_StudentTBL();
            showProfessorStudent();
        }

        private void setColumnHearders()
        {
            LectureDBGrid.Columns["LEC_NAME"].HeaderText = "강의명";
            LectureDBGrid.Columns["LEC_CREDIT"].HeaderText = "학점";
            LectureDBGrid.Columns["LEC_ROOM"].HeaderText = "강의실";

            MyStudentList.Columns["STU_NUM"].HeaderText = "학번";
            MyStudentList.Columns["STU_NAME"].HeaderText = "이름";
            MyStudentList.Columns["STU_GRADE"].HeaderText = "학년";
            MyStudentList.Columns["STU_TEL"].HeaderText = "전화번호";
            MyStudentList.Columns["STU_ADDR"].HeaderText = "주소";
            MyStudentList.Columns["STU_ADMISSION_DATE"].HeaderText = "입학일";
            MyStudentList.Columns["STU_BIRTH"].HeaderText = "생일";
        }

        private void Set_Student_Info_Change_Form(Student_Info_Change dlg)
        {
            s_dbc.CommandString = "select stu_num, stu_name, stu_condition, stu_addr, dept_name, prof_name, stu_tel from student A, (Select professor.prof_num, professor.prof_name, dept.dept_name from professor, dept where professor.dept_code = dept.dept_code) B where A.stu_main_prof = prof_num AND A.stu_num = '" + TargetStuNum_Student_DBGrid + "'";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                dlg.Stu_Num_Text = s_dbc.DataReader[0].ToString();
                dlg.Stu_Name_Text = s_dbc.DataReader[1].ToString();
                dlg.Stu_Condition = s_dbc.DataReader[2].ToString();
                dlg.Stu_Addr = s_dbc.DataReader[3].ToString();
                dlg.Stu_Major_Text = s_dbc.DataReader[4].ToString();
                dlg.Stu_Main_Prof_Text = s_dbc.DataReader[5].ToString();
                dlg.Stu_Tel = s_dbc.DataReader[6].ToString();
            }
            s_dbc.MyConnection.Close();
        }

        private void Set_Student_Info_Input_Form(Student_Info_Input dlg)
        {

            s_dbc.CommandString = "SELECT professor.prof_name, dept_name, professor.prof_num, dept.dept_code FROM PROFESSOR, DEPT WHERE prof_num = '" + professor_code + "'AND DEPT.dept_code = PROFESSOR.dept_code";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                dlg.Stu_Main_Prof_Name = s_dbc.DataReader[0].ToString();
                dlg.Stu_Major_Name = s_dbc.DataReader[1].ToString();

                dlg.Stu_Main_Prof = s_dbc.DataReader[2].ToString();
                dlg.Stu_Major = s_dbc.DataReader[3].ToString();
            }
            s_dbc.MyConnection.Close();
        }

        private void Professor_main_Load(object sender, EventArgs e)
        {
            txtSearch.Select();

            try
            {
                showProfessorInfo();
                showProfessorLecture();
                showProfessorStudent();
                setColumnHearders();
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

        private void MyStudentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                else if (e.RowIndex > stu_cud_dbc.RefTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                TargetStuNum_Student_DBGrid = MyStudentList.SelectedRows[0].Cells[0].Value.ToString();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                createStudent();
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            try { 
                modifyStudent();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteStudent();
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

        private void btnSearchStuent_Click(object sender, EventArgs e)
        {
            SearchText = txtSearch.Text;

            Consultation_Management cm = new Consultation_Management();
            cm.Owner = this;
            cm.ShowDialog();
            cm.Dispose();
        }
    }
}
