namespace SchoolManagementSystem
{
    partial class Lecture_Info_Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLectureName = new System.Windows.Forms.TextBox();
            this.txtLectureCode = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLectureRoom = new System.Windows.Forms.TextBox();
            this.classifyComboBox = new System.Windows.Forms.ComboBox();
            this.creditComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔바른펜", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(24, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "강의명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔바른펜", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "강의코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLectureName
            // 
            this.txtLectureName.Location = new System.Drawing.Point(102, 79);
            this.txtLectureName.Name = "txtLectureName";
            this.txtLectureName.Size = new System.Drawing.Size(138, 28);
            this.txtLectureName.TabIndex = 17;
            // 
            // txtLectureCode
            // 
            this.txtLectureCode.Location = new System.Drawing.Point(102, 29);
            this.txtLectureCode.Name = "txtLectureCode";
            this.txtLectureCode.Size = new System.Drawing.Size(138, 28);
            this.txtLectureCode.TabIndex = 17;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(103, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLectureRoom);
            this.groupBox1.Controls.Add(this.classifyComboBox);
            this.groupBox1.Controls.Add(this.creditComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLectureName);
            this.groupBox1.Controls.Add(this.txtLectureCode);
            this.groupBox1.Font = new System.Drawing.Font("나눔바른펜", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(27, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 295);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "정보 입력";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔바른펜", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(25, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "강의실";
            // 
            // txtLectureRoom
            // 
            this.txtLectureRoom.Location = new System.Drawing.Point(103, 128);
            this.txtLectureRoom.Name = "txtLectureRoom";
            this.txtLectureRoom.Size = new System.Drawing.Size(138, 28);
            this.txtLectureRoom.TabIndex = 30;
            // 
            // classifyComboBox
            // 
            this.classifyComboBox.BackColor = System.Drawing.Color.White;
            this.classifyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classifyComboBox.FormattingEnabled = true;
            this.classifyComboBox.Items.AddRange(new object[] {
            "전공",
            "교양"});
            this.classifyComboBox.Location = new System.Drawing.Point(102, 230);
            this.classifyComboBox.Name = "classifyComboBox";
            this.classifyComboBox.Size = new System.Drawing.Size(137, 29);
            this.classifyComboBox.TabIndex = 29;
            // 
            // creditComboBox
            // 
            this.creditComboBox.BackColor = System.Drawing.Color.White;
            this.creditComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.creditComboBox.FormattingEnabled = true;
            this.creditComboBox.Items.AddRange(new object[] {
            "1학점",
            "2학점",
            "3학점"});
            this.creditComboBox.Location = new System.Drawing.Point(102, 180);
            this.creditComboBox.Name = "creditComboBox";
            this.creditComboBox.Size = new System.Drawing.Size(137, 29);
            this.creditComboBox.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔바른펜", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(24, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "강의학점";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔바른펜", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(24, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "강의구분";
            // 
            // Lecture_Info_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 399);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "Lecture_Info_Input";
            this.Text = "강의 정보 입력";
            this.Load += new System.EventHandler(this.New_Lecture_Info_Input_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLectureName;
        private System.Windows.Forms.TextBox txtLectureCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLectureRoom;
        private System.Windows.Forms.ComboBox classifyComboBox;
        private System.Windows.Forms.ComboBox creditComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}