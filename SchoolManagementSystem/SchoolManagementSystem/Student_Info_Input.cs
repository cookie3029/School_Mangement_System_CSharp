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
    public partial class Student_Info_Input : Form
    {
        private string stu_num, stu_name, stu_grade, stu_condition;
        private string stu_addr, stu_tel, stu_birth, stu_admission_date;
        private string stu_major, stu_main_prof, stu_major_name, stu_main_prof_name;

        public string Stu_Num { get { return stu_num; } set { stu_num = value.ToString(); } }
        public string Stu_Name { get { return stu_name; } set { stu_name = value.ToString(); } }

        public string Stu_Tel { get { return stu_tel; } set { stu_tel = value.ToString(); } }
        public string Stu_Addr { get { return stu_addr; } set { stu_addr = value.ToString(); } }

        public string Stu_Major { get { return stu_major; } set { stu_major = value.ToString(); } }
        public string Stu_Main_Prof { get { return stu_main_prof; } set { stu_main_prof = value.ToString(); } }

        public string Stu_Major_Name { get { return stu_major_name; } set { stu_major_name = value.ToString(); } }
        public string Stu_Main_Prof_Name { get { return stu_main_prof_name; } set { stu_main_prof_name = value.ToString(); } }

        public string Stu_Grade { get { return stu_grade; } set { stu_grade = value.ToString(); } }
        public string Stu_Condition { get { return stu_condition; } set { stu_condition = value.ToString(); } }

        public string Stu_Birth { get { return stu_birth; } set { stu_birth = value.ToString(); } }
        public string Stu_Admission_Date { get { return stu_admission_date; } set { stu_admission_date = value.ToString(); } }

        public Student_Info_Input()
        {
            InitializeComponent();
        }

        private void New_Student_Info_Input_Load(object sender, EventArgs e)
        {
            gradeComboBox.SelectedIndex = 0;
            conditionComboBox.SelectedIndex = 0;

            txtMajor.Text = Stu_Major_Name;
            txtMainProf.Text = Stu_Main_Prof_Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stu_Num = txtNum.Text;
            Stu_Name = txtName.Text;

            Stu_Tel = txtTel.Text;
            Stu_Addr = txtAddr.Text;

            Stu_Grade = gradeComboBox.SelectedItem.ToString();
            Stu_Condition = conditionComboBox.SelectedItem.ToString();

            Stu_Birth = birthDateTimePicker.Value.ToString("yyyy-MM-dd");
            Stu_Admission_Date = admissionDateTimePicker.Value.ToString("yyyy-MM-dd");

        }
    }
}
