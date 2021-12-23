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
    public partial class Professor_MDI : Form
    {
        Professor_Main p_main;
        Prof_Lecture_Managerment p_lsm;
        Login login;

        private int professor_code;

        public int Professor_Code
        {
            get { return this.professor_code; }
            set { this.professor_code = value; }
        }

        public Professor_MDI()
        {
            InitializeComponent();
        }

        private void showProfessorForm()
        {
            p_main = new Professor_Main(Professor_Code);
            p_main.MdiParent = this;
            p_main.Show();
        }

        private void showStudentForm()
        {
            p_lsm = new Prof_Lecture_Managerment(Professor_Code);
            p_lsm.MdiParent = this;
            p_lsm.Show();
        }

        private void Professor_MDI_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            showProfessorForm();
        }

        private void 강의학생관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (p_lsm == null || p_lsm.IsDisposed) //Form3
            {
                showStudentForm();
                p_main.Dispose();
            }
        }

        private void 메인화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (p_main == null || p_main.IsDisposed) //Form3
            {
                showProfessorForm();
                p_lsm.Dispose();
            }
        }

        private void Professor_MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            login = (Login)Owner;
            login.Show();
            this.Hide();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login = (Login)Owner;
            login.Show();
            this.Hide();
        }
    }
}
