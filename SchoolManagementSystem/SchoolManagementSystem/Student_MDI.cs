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
    public partial class Student_MDI : Form
    {
        Student_Main p_main;
        Login login;

        private int student_code;

        public int Student_Code
        {
            get { return this.student_code; }
            set { this.student_code = value; }
        }

        public Student_MDI()
        {
            InitializeComponent();
        }

        private void Student_MDI_Load(object sender, EventArgs e)
        {
            p_main = new Student_Main(Student_Code);
            p_main.MdiParent = this;
            p_main.Show();
        }

        private void Student_MDI_FormClosing(object sender, FormClosingEventArgs e)
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