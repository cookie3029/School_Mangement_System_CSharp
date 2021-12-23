namespace SchoolManagementSystem
{
    partial class Prof_Lecture_Managerment
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
            this.components = new System.ComponentModel.Container();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.LectureLearnerDBGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LectureDBGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.강의생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.강의수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.강의삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LectureLearnerDBGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LectureDBGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.LectureLearnerDBGrid);
            this.groupBox4.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(516, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(527, 510);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "수강학생관리";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A+",
            "A",
            "B+",
            "B",
            "C+",
            "C",
            "D+",
            "D",
            "F"});
            this.comboBox1.Location = new System.Drawing.Point(259, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // LectureLearnerDBGrid
            // 
            this.LectureLearnerDBGrid.AllowUserToAddRows = false;
            this.LectureLearnerDBGrid.AllowUserToResizeRows = false;
            this.LectureLearnerDBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LectureLearnerDBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LectureLearnerDBGrid.Location = new System.Drawing.Point(31, 67);
            this.LectureLearnerDBGrid.MultiSelect = false;
            this.LectureLearnerDBGrid.Name = "LectureLearnerDBGrid";
            this.LectureLearnerDBGrid.ReadOnly = true;
            this.LectureLearnerDBGrid.RowHeadersVisible = false;
            this.LectureLearnerDBGrid.RowTemplate.Height = 23;
            this.LectureLearnerDBGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LectureLearnerDBGrid.Size = new System.Drawing.Size(459, 413);
            this.LectureLearnerDBGrid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LectureDBGrid);
            this.groupBox1.Font = new System.Drawing.Font("나눔바른고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(43, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 510);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "강의관리";
            // 
            // LectureDBGrid
            // 
            this.LectureDBGrid.AllowUserToAddRows = false;
            this.LectureDBGrid.AllowUserToResizeRows = false;
            this.LectureDBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.LectureDBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LectureDBGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.LectureDBGrid.Location = new System.Drawing.Point(26, 38);
            this.LectureDBGrid.MultiSelect = false;
            this.LectureDBGrid.Name = "LectureDBGrid";
            this.LectureDBGrid.ReadOnly = true;
            this.LectureDBGrid.RowHeadersVisible = false;
            this.LectureDBGrid.RowTemplate.Height = 23;
            this.LectureDBGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LectureDBGrid.Size = new System.Drawing.Size(377, 442);
            this.LectureDBGrid.TabIndex = 0;
            this.LectureDBGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LectureDBGrid_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.강의생성ToolStripMenuItem,
            this.강의수정ToolStripMenuItem,
            this.강의삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 70);
            // 
            // 강의생성ToolStripMenuItem
            // 
            this.강의생성ToolStripMenuItem.Name = "강의생성ToolStripMenuItem";
            this.강의생성ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.강의생성ToolStripMenuItem.Text = "강의생성";
            this.강의생성ToolStripMenuItem.Click += new System.EventHandler(this.강의생성ToolStripMenuItem_Click);
            // 
            // 강의수정ToolStripMenuItem
            // 
            this.강의수정ToolStripMenuItem.Name = "강의수정ToolStripMenuItem";
            this.강의수정ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.강의수정ToolStripMenuItem.Text = "강의수정";
            this.강의수정ToolStripMenuItem.Click += new System.EventHandler(this.강의수정ToolStripMenuItem_Click);
            // 
            // 강의삭제ToolStripMenuItem
            // 
            this.강의삭제ToolStripMenuItem.Name = "강의삭제ToolStripMenuItem";
            this.강의삭제ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.강의삭제ToolStripMenuItem.Text = "강의삭제";
            this.강의삭제ToolStripMenuItem.Click += new System.EventHandler(this.강의삭제ToolStripMenuItem_Click);
            // 
            // Prof_Lecture_Managerment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 679);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Prof_Lecture_Managerment";
            this.Text = "교수 전용";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Prof_Lecture_Managerment_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LectureLearnerDBGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LectureDBGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView LectureLearnerDBGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView LectureDBGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 강의생성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 강의수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 강의삭제ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}