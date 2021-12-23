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
    public partial class Student_Info_Change : Form
    {
        private string stu_condition, stu_addr, stu_tel;

        public string Stu_Tel { get { return stu_tel; } set { stu_tel = value.ToString(); } }
        public string Stu_Addr { get { return stu_addr; } set { stu_addr = value.ToString(); } }
        public string Stu_Condition { get { return stu_condition; } set { stu_condition = value.ToString(); } }

        public string Stu_Num_Text { set { txtNum.Text = value.ToString(); } }
        public string Stu_Name_Text { set { txtName.Text = value.ToString(); } }
        public string Stu_Major_Text { set { txtMajor.Text = value.ToString(); } }
        public string Stu_Main_Prof_Text { set { txtMainProf.Text = value.ToString(); } }

        public Student_Info_Change()
        {
            InitializeComponent();
        }

        private void Student_Info_Change_Load(object sender, EventArgs e)
        {
            conditionComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) {
            Stu_Tel = txtTel.Text;
            Stu_Addr = txtAddr.Text;
            Stu_Condition = conditionComboBox.SelectedItem.ToString();
          }
    }
}
