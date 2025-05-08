namespace Final_Report_0507
{
    partial class ReturnForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            lblName = new Label();
            txtIdNumber = new TextBox();
            dgvBooks = new DataGridView();
            chk = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Publisher = new DataGridViewTextBoxColumn();
            PublishDate = new DataGridViewTextBoxColumn();
            AgeRating = new DataGridViewTextBoxColumn();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "學號: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F);
            label2.Location = new Point(277, 9);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "姓名: ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft JhengHei UI", 12F);
            lblName.Location = new Point(332, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 2;
            // 
            // txtIdNumber
            // 
            txtIdNumber.Location = new Point(67, 8);
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(100, 23);
            txtIdNumber.TabIndex = 3;
            txtIdNumber.KeyDown += txtIdNumber_KeyDown;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { chk, Id, Title, Author, Publisher, PublishDate, AgeRating });
            dgvBooks.Location = new Point(12, 37);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(560, 449);
            dgvBooks.TabIndex = 4;
            // 
            // chk
            // 
            chk.HeaderText = "選取";
            chk.Name = "chk";
            chk.Width = 40;
            // 
            // Id
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Id.DefaultCellStyle = dataGridViewCellStyle2;
            Id.HeaderText = "編號";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 50;
            // 
            // Title
            // 
            Title.HeaderText = "書名";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Author
            // 
            Author.HeaderText = "作者";
            Author.Name = "Author";
            Author.ReadOnly = true;
            // 
            // Publisher
            // 
            Publisher.HeaderText = "出版社";
            Publisher.Name = "Publisher";
            Publisher.ReadOnly = true;
            // 
            // PublishDate
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PublishDate.DefaultCellStyle = dataGridViewCellStyle3;
            PublishDate.HeaderText = "發行日";
            PublishDate.Name = "PublishDate";
            PublishDate.ReadOnly = true;
            // 
            // AgeRating
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AgeRating.DefaultCellStyle = dataGridViewCellStyle4;
            AgeRating.HeaderText = "分級";
            AgeRating.Name = "AgeRating";
            AgeRating.ReadOnly = true;
            AgeRating.Width = 50;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(368, 499);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 50);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(117, 499);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 50);
            btnSave.TabIndex = 19;
            btnSave.Text = "確定";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ReturnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dgvBooks);
            Controls.Add(txtIdNumber);
            Controls.Add(lblName);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "ReturnForm";
            Text = "還書";
            KeyDown += Form_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblName;
        private TextBox txtIdNumber;
        private DataGridView dgvBooks;
        private DataGridViewCheckBoxColumn chk;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Publisher;
        private DataGridViewTextBoxColumn PublishDate;
        private DataGridViewTextBoxColumn AgeRating;
        private Button btnCancel;
        private Button btnSave;
    }
}