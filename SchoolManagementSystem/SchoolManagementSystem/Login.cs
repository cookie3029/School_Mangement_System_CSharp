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
    public partial class Login : Form
    {
        SELECT_DBClass s_dbc = new SELECT_DBClass();

        public Login()
        {
            InitializeComponent();
            s_dbc.DB_Select_Mode_Open();
        }

        private void setCommandString()
        {
            if (radioButton1.Checked)
            {
                s_dbc.CommandString = "SELECT PROF_PASSWORD FROM PROFESSOR WHERE PROF_NUM = " + txtId.Text;
            }

            if (radioButton2.Checked)
            {
                s_dbc.CommandString = "SELECT STU_PASSWORD FROM STUDENT WHERE STU_NUM = " + txtId.Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                setCommandString();
                s_dbc.DB_Select_By_DataReader();

                if (radioButton1.Checked && s_dbc.DataReader.Read() && s_dbc.DataReader[0].Equals(txtPassword.Text))
                {
                    Professor_MDI p_mdi = new Professor_MDI();
                    p_mdi.Professor_Code = Convert.ToInt32(txtId.Text);
                    p_mdi.Owner = this;
                    p_mdi.Show();
                    this.Hide();
                }
                else if (radioButton2.Checked && s_dbc.DataReader.Read() && s_dbc.DataReader[0].Equals(txtPassword.Text))
                {
                    Student_MDI s_mdi = new Student_MDI();
                    s_mdi.Student_Code = Convert.ToInt32(txtId.Text);
                    s_mdi.Owner = this;
                    s_mdi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("로그인에 실패하셨습니다.");
                }
                s_dbc.MyConnection.Close();
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
            Student_Num_AND_Professor_Code_PW_List snapc = new Student_Num_AND_Professor_Code_PW_List();
            snapc.ShowDialog();
        }
    }
}
