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
    public partial class Make_Consult_Record : Form
    {
        private string content;
        private string date;

        public string Content
        {
            get { return content; }
            set { content = value.ToString(); }
        }

        public string Date
        {
            get { return date; }
            set { date = value.ToString(); }
        }


        public Make_Consult_Record()
        {
            InitializeComponent();
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Content = contentTextBox.Text;

            Date = dateTimePicker1.Value.ToString("yyyy-MM-dd");  
        }
    }
}