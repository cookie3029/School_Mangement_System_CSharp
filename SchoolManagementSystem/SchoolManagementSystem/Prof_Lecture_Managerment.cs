using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace SchoolManagementSystem
{
    public partial class Prof_Lecture_Managerment : Form
    {
        SELECT_DBClass s_dbc = new SELECT_DBClass();
        LECTURE_WITH_CONTEXTMENU_DBClass lec_cud_dbc = new LECTURE_WITH_CONTEXTMENU_DBClass();


        private int professor_code;
        private string strCommand;
        private int targetLectureCode;

        private int max_rows_count;
        private int learner_num;

        public int TargetLectureCode
        {
            get { return targetLectureCode; }
            set { this.targetLectureCode = value; }
        }

        public int Professor_Code
        {
            get { return professor_code; }
            set { this.professor_code = value; }
        }

        public string GetstrCommand
        {
            get { return strCommand; }
        }

        public int Max_Rows_Count
        {
            get { return max_rows_count; }
            set { max_rows_count = value; }
        }

        public int Learner_Num
        {
            get { return learner_num; }
            set { learner_num = value; }
        }

        public Prof_Lecture_Managerment(int _professor_code)
        {
            InitializeComponent();
            Professor_Code = _professor_code;
            s_dbc.DB_Select_Mode_Open();
            lec_cud_dbc.DB_CRUD_Mode_Open();
        }

        private void setColumnHearders() //form_load 이벤트 소속 함수
        {

            LectureDBGrid.Columns["LEC_CODE"].HeaderText = "강의코드";
            LectureDBGrid.Columns["LEC_NAME"].HeaderText = "강의명";
            LectureDBGrid.Columns["LEC_CREDIT"].HeaderText = "학점";
            LectureDBGrid.Columns["LEC_ROOM"].HeaderText = "강의실";
            LectureDBGrid.Columns["LEC_CLASSIFY"].HeaderText = "강의구분";

            LectureLearnerDBGrid.Columns["STU_NUM"].HeaderText = "학번";
            LectureLearnerDBGrid.Columns["STU_NAME"].HeaderText = "이름";
            LectureLearnerDBGrid.Columns["STU_GRADE"].HeaderText = "학년";
            LectureLearnerDBGrid.Columns["STU_BIRTH"].HeaderText = "생일";
            LectureLearnerDBGrid.Columns["STU_ADMISSION_DATE"].HeaderText = "입학일";
            LectureLearnerDBGrid.Columns["LEARNER_GRADE"].HeaderText = "평점";
        }

        private void showProfessorLecture()
        {
            s_dbc.CommandString = "Select A.LEC_CODE, A.LEC_NAME, A.LEC_CREDIT, A.LEC_ROOM,  A.LEC_CLASSIFY FROM LECTURE A, (SELECT * FROM Professor, lecture_teach WHERE professor.prof_num = lecture_teach.prof_num and professor.prof_num = '" + Professor_Code + "') B WHERE a.lec_code = B.LEC_CODE";
            s_dbc.DB_Select_By_DBAdaper("LectureList");
            LectureDBGrid.DataSource = s_dbc.RefTable;
        }

        private void showLectureLearner()
        {
            TargetLectureCode = Convert.ToInt32(LectureDBGrid.SelectedRows[0].Cells[0].Value);
            s_dbc.CommandString = "Select S.STU_NUM, S.STU_NAME, S.STU_GRADE, S.STU_BIRTH, S.STU_ADMISSION_DATE, L.LEARNER_GRADE from student s, lecture_learner l where S.STU_NUM = L.STU_NUM AND L.LEC_CODE = " + TargetLectureCode;
            s_dbc.DB_Select_By_DBAdaper("LECTURE_LEARNER"); //데이터 어댑터 모드로 대상 테이블을 조회
            LectureLearnerDBGrid.DataSource = s_dbc.DS.Tables["LECTURE_LEARNER"].DefaultView;

            Learner_Num = s_dbc.RefTable.Rows.Count - 1;
        }

        private void Prof_Lecture_Managerment_Load(object sender, EventArgs e)
        {
            showProfessorLecture();
            showLectureLearner();
            setColumnHearders();
        }

        private void LectureDBGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Max_Rows_Count = LectureDBGrid.Rows.Count;

                if (e.RowIndex < 0)
                {
                    return;
                }
                else if (e.RowIndex > Max_Rows_Count)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }

                showLectureLearner();
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

        private void 강의생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strCommand = "추가";
            Lecture_Info_Input input = new Lecture_Info_Input(this);
            input.ShowDialog();
            input.Dispose();

            showProfessorLecture();
        }

        private void 강의수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LectureDBGrid.SelectedRows.Count < 0)
            {
                MessageBox.Show("수정할 강의를 먼저 선택하세요");
            }
            else
            {
                strCommand = "업데이트";
                Lecture_Info_Input change = new Lecture_Info_Input(this);
                change.ShowDialog();
                change.Dispose();

                showProfessorLecture();
            }
        }

        private void 강의삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LectureDBGrid.SelectedRows.Count < 0)
            {
                MessageBox.Show("삭제할 강의를 먼저 선택하세요");
            }
            else if (Learner_Num > 0)
            {
                MessageBox.Show("수강생이 있는 강의는 삭제할 수 없습니다.");
            }
            else
            {
                strCommand = "삭제";
                //intID = Convert.ToInt32(DBGrid.SelectedCells[0].Value);
                Lecture_Info_Input delete = new Lecture_Info_Input(this);
                delete.ShowDialog();
                delete.Dispose();

                showProfessorLecture();
            }
        }

        private void button1_Click(object sender, EventArgs e) //별도의 클래스를 사용하지 않고 직접 작성
        {
            if (LectureLearnerDBGrid.Rows.Count < 0 || LectureLearnerDBGrid.SelectedRows.Count < 0)
            {
                MessageBox.Show("학생을 선택하세요!!");
            }
            else
            {
                string commandString;
                string learner_grade = comboBox1.SelectedItem.ToString();
                string student_num = LectureLearnerDBGrid.SelectedRows[0].Cells[0].Value.ToString();

                OracleConnection myConnection = new OracleConnection();
                myConnection.ConnectionString = "User Id=test; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                myConnection.Open();

                commandString = "UPDATE lecture_learner SET learner_grade = '" + learner_grade + "' WHERE lec_code =" + TargetLectureCode + "AND stu_num = '" + student_num + "'";

                OracleCommand OraCmd = new OracleCommand(commandString, myConnection);

                if (OraCmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("평점 부여가 완료되었습니다.");
                    showLectureLearner();
                }

                myConnection.Close();
            }
        }
    }
 }
