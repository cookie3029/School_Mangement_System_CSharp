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
    public partial class Lecture_Info_Input : Form
    {

        Prof_Lecture_Managerment _parent;
        SELECT_DBClass s_dbc = new SELECT_DBClass();
        LECTURE_WITH_CONTEXTMENU_DBClass lec_context_dbc = new LECTURE_WITH_CONTEXTMENU_DBClass();

        private string lec_code;
        private string lec_name;
        private string lec_room;
        private string lec_classify;
        private int lec_credit;

        public string Lec_Code
        {
            get { return lec_code; }
            set { lec_code = txtLectureCode.Text; }
        }

        public string Lec_Name
        {
            get { return lec_name; }
            set { lec_name = txtLectureName.Text; }
        }

        public string Lec_Room
        {
            get { return lec_room; }
            set { lec_room = txtLectureRoom.Text; }
        }



        public Lecture_Info_Input(Prof_Lecture_Managerment inform)
        {
            InitializeComponent();
            _parent = inform;
            s_dbc.DB_Select_Mode_Open();
            lec_context_dbc.DB_CRUD_Mode_Open();
        }

        private void initialization()
        {
            s_dbc.CommandString = "Select A.LEC_CODE, A.LEC_NAME, A.LEC_ROOM, A.LEC_CREDIT, A.LEC_CLASSIFY FROM LECTURE A, (SELECT * FROM Professor, lecture_teach WHERE professor.prof_num = lecture_teach.prof_num and professor.prof_num = '" + _parent.Professor_Code + "') B WHERE a.lec_code = B.LEC_CODE AND a.lec_code = '" + _parent.TargetLectureCode + "'";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                txtLectureCode.Text = Convert.ToString(s_dbc.DataReader.GetValue(0));
                txtLectureName.Text = Convert.ToString(s_dbc.DataReader.GetValue(1));
                txtLectureRoom.Text = Convert.ToString(s_dbc.DataReader.GetValue(2));
                creditComboBox.SelectedItem = Convert.ToString(s_dbc.DataReader.GetValue(3)) + "학점";
                classifyComboBox.SelectedItem = Convert.ToString(s_dbc.DataReader.GetValue(4));
            }
            s_dbc.DataReader.Close();
            s_dbc.MyConnection.Close();
        }


        private void New_Lecture_Info_Input_Load(object sender, EventArgs e)
        {
            creditComboBox.SelectedIndex = 0;
            classifyComboBox.SelectedIndex = 0;

            if (_parent.GetstrCommand == "삭제")
            {
                btnOK.Text = "삭제";
                txtLectureCode.ReadOnly = true;
                txtLectureName.ReadOnly = true;
                txtLectureRoom.ReadOnly = true;
                creditComboBox.Enabled = false;
                classifyComboBox.Enabled = false;
                initialization();
            }
            else if (_parent.GetstrCommand == "업데이트")
            {
                btnOK.Text = "업데이트";
                txtLectureCode.ReadOnly = true;
                txtLectureName.ReadOnly = true;
                txtLectureRoom.ReadOnly = true;
                initialization();
            }
            else btnOK.Text = "추가";
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Text == "추가")
            {
                if (INSERTRow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 추가됨.");
                }
                else MessageBox.Show("데이터 행이 추가되지 않음!");
                this.Close();
            }
            else if (btnOK.Text == "삭제")
            {
                if (DELETERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 삭제됨!");
                }
                else MessageBox.Show("데이터 행이 삭제되지 않음!");
                this.Close();
            }
            else
            {
                if (UPDATERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터가 업데이트됨!");
                }
                else MessageBox.Show("데이터 행이 업데이트되지 않음!");
                this.Close();
            }
        }

        private int INSERTRow()//사용자 함수 정의
        {
            int inLectureCode = Convert.ToInt32(txtLectureCode.Text.Trim()); //**
            String inLectureName = txtLectureName.Text.Trim(); //**
            String inLectureRoom = txtLectureRoom.Text.Trim(); //**
            String inLectureClassify = classifyComboBox.SelectedItem.ToString().Trim(); //**

            int inLectureCredit = Convert.ToInt32(creditComboBox.SelectedIndex) + 1; //**

            int result_row_count = lec_context_dbc.DB_Create_Lecture_With_ConetextMenu(inLectureCode, inLectureName, inLectureCredit, inLectureRoom, inLectureClassify, _parent.Professor_Code);
            return result_row_count;
        }

        private int UPDATERow() //사용자 함수 정의
        {
            int inLectureCredit = Convert.ToInt32(creditComboBox.SelectedIndex) + 1; //**
            String inLectureClassify = classifyComboBox.SelectedItem.ToString().Trim(); //**

            int result_row_count = lec_context_dbc.DB_Update_Lecture_With_ConetextMenu(_parent.TargetLectureCode, inLectureCredit, inLectureClassify);
            return result_row_count;
        }

        private int DELETERow() //사용자 함수 정의
        {
            int result_row_count = lec_context_dbc.DB_Delete_Lecture_With_ConetextMenu(_parent.TargetLectureCode);
            return result_row_count;
        }
    }
}
