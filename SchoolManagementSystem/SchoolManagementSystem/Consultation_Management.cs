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
    public partial class Consultation_Management : Form
    {
        Professor_Main Parent;
        SELECT_DBClass s_dbc = new SELECT_DBClass(); //테이블을 조회하기 위한 클래스
        CONSULT_LIST_CREATE_DBClass clcd = new CONSULT_LIST_CREATE_DBClass();


        public Consultation_Management()
        {
            InitializeComponent();
            s_dbc.DB_Select_Mode_Open();
            clcd.DB_CONSULT_CREATE_Mode_Open();
        }

        private void showConsultDate()
        {
            if (consultDateView.Items.Count > 0)
            {
                consultDateView.Items.Clear();
            }

            s_dbc.CommandString = "select * from consulting where stu_num = '" + s_dbc.SelectedKeyValue + "' ORDER BY CONSULT_NO ASC";
            s_dbc.DB_Select_By_DataReader();


            while (s_dbc.DataReader.Read())
            {
                ListViewItem item = new ListViewItem(s_dbc.DataReader["consult_no"].ToString());
                item.SubItems.Add(string.Format("{0:yyyy/MM/dd}", s_dbc.DataReader["CONSULT_DATE"]));
                consultDateView.Items.Add(item);
            }
            s_dbc.MyConnection.Close();
        }

        private void showStudentList()
        {
            s_dbc.CommandString = "SELECT * FROM STUDENT WHERE stu_main_prof = '" + Parent.Professor_Code + "' ORDER BY stu_num asc";
            s_dbc.DB_Select_By_DBAdaper("StudentList");

            DataRow[] ResultRows = s_dbc.RefTable.Select("STU_NAME like '%" + Parent.SearchText + "%'");

            studentListView.Items.Clear();
            foreach (DataRow currRow in ResultRows)
            {
                ListViewItem item = new ListViewItem(currRow["STU_NUM"].ToString());
                item.SubItems.Add(currRow["STU_NAME"].ToString());
                item.SubItems.Add(currRow["STU_GRADE"].ToString());
                item.SubItems.Add(currRow["STU_TEL"].ToString());
                item.SubItems.Add(string.Format("{0:yyyy/MM/dd}", currRow["STU_ADMISSION_DATE"]));
                item.SubItems.Add(string.Format("{0:yyyy/MM/dd}", currRow["STU_BIRTH"]));

                studentListView.Items.Add(item);
            }
        }

        private void setTextBoxStudentInfo()
        {
            DataColumn[] PrimaryKey = new DataColumn[1];
            PrimaryKey[0] = s_dbc.RefTable.Columns["STU_NUM"];
            s_dbc.RefTable.PrimaryKey = PrimaryKey;
            DataRow currRow = s_dbc.RefTable.Rows.Find(studentListView.Items[studentListView.SelectedItems[0].Index].SubItems[0].Text);
            s_dbc.SelectedKeyValue = currRow["STU_NUM"].ToString();

            txtNum.Text = currRow["STU_NUM"].ToString();
            txtName.Text = currRow["STU_NAME"].ToString();
            txtCondition.Text = currRow["STU_CONDITION"].ToString();
            txtGrade.Text = currRow["STU_GRADE"].ToString();
            txtAddr.Text = currRow["STU_ADDR"].ToString();
            txtTel.Text = currRow["STU_TEL"].ToString();
            txtBirth.Text = string.Format("{0:yyyy/MM/dd}", currRow["STU_BIRTH"]);
        }

        private int getNewConsultNum()
        {
            int newConsult_num = 1;

            s_dbc.CommandString = "select NVL(MAX(CONSULT_NO), 0) from consulting where stu_num = '" + s_dbc.SelectedKeyValue + "' ORDER BY CONSULT_NO ASC";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                newConsult_num = Convert.ToInt32(s_dbc.DataReader[0].ToString());
            }
            s_dbc.MyConnection.Close();

            return newConsult_num;
        }

        private void setConsultContentToLabel()
        {
            s_dbc.CommandString = "select consult_content from consulting where stu_num = '" + s_dbc.SelectedKeyValue + "' AND consult_no = " + Convert.ToInt32(consultDateView.SelectedItems[0].Text) + "";
            s_dbc.DB_Select_By_DataReader();

            while (s_dbc.DataReader.Read())
            {
                contentLabel.Text = s_dbc.DataReader[0].ToString();
            }
            s_dbc.MyConnection.Close();
        }

        private void Consulation_Management_Load(object sender, EventArgs e)
        {
            Parent = (Professor_Main)Owner;

            try
            {
                showStudentList();
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

        private void studentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Parent = (Professor_Main)Owner;

            try
            {
                if (studentListView.SelectedItems.Count > 0)
                {
                    setTextBoxStudentInfo();
                    showConsultDate();
                    contentLabel.Text = "";
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

        private void consultDateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (consultDateView.SelectedItems.Count > 0)
                {
                    setConsultContentToLabel();
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

        private void btnMakeConsultContent_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentListView.SelectedItems.Count > 0)
                {
                    Make_Consult_Record dlg = new Make_Consult_Record();

                    int newConsult_num = getNewConsultNum();

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        clcd.DB_Create_At_ConsultTBL(newConsult_num + 1, s_dbc.SelectedKeyValue, dlg.Date, dlg.Content);
                        consultDateView.Items.Clear();
                        contentLabel.Text = "";
                        MessageBox.Show("면담 기록이 무사히 추가되었습니다.");
                    }
                    dlg.Dispose();
                }
                else
                {
                    MessageBox.Show("학생을 선택하시고 클릭해주세요!!");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}


