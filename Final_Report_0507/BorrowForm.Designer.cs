namespace Final_Report_0507
{
    partial class BorrowForm
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
            txtIdNumber = new TextBox();
            label2 = new Label();
            lblName = new Label();
            label3 = new Label();
            label4 = new Label();
            txtBookId = new TextBox();
            lblAgeRating = new Label();
            groupBox1 = new GroupBox();
            lblPublisher = new Label();
            lblPublishDate = new Label();
            lblAuthor = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            dgvBooks = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Publisher = new DataGridViewTextBoxColumn();
            PublishDate = new DataGridViewTextBoxColumn();
            AgeRating = new DataGridViewTextBoxColumn();
            btnCancel = new Button();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F);
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "學號: ";
            // 
            // txtIdNumber
            // 
            txtIdNumber.Location = new Point(67, 28);
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(100, 23);
            txtIdNumber.TabIndex = 1;
            txtIdNumber.KeyDown += txtIdNumber_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F);
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "姓名: ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft JhengHei UI", 12F);
            lblName.Location = new Point(67, 74);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F);
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "書籍編號: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F);
            label4.Location = new Point(208, 19);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 0;
            label4.Text = "分級: ";
            // 
            // txtBookId
            // 
            txtBookId.Location = new Point(93, 18);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(100, 23);
            txtBookId.TabIndex = 6;
            txtBookId.KeyDown += txtBookId_KeyDown;
            // 
            // lblAgeRating
            // 
            lblAgeRating.AutoSize = true;
            lblAgeRating.Font = new Font("Microsoft JhengHei UI", 12F);
            lblAgeRating.Location = new Point(263, 19);
            lblAgeRating.Name = "lblAgeRating";
            lblAgeRating.Size = new Size(0, 20);
            lblAgeRating.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPublisher);
            groupBox1.Controls.Add(lblPublishDate);
            groupBox1.Controls.Add(lblAuthor);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblAgeRating);
            groupBox1.Controls.Add(txtBookId);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(214, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 167);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Font = new Font("Microsoft JhengHei UI", 12F);
            lblPublisher.Location = new Point(77, 99);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(0, 20);
            lblPublisher.TabIndex = 10;
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Font = new Font("Microsoft JhengHei UI", 12F);
            lblPublishDate.Location = new Point(77, 139);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(0, 20);
            lblPublishDate.TabIndex = 9;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Microsoft JhengHei UI", 12F);
            lblAuthor.Location = new Point(61, 59);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(0, 20);
            lblAuthor.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 12F);
            label7.Location = new Point(6, 139);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 0;
            label7.Text = "發行日: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F);
            label6.Location = new Point(6, 99);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 0;
            label6.Text = "出版社: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F);
            label5.Location = new Point(6, 59);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 0;
            label5.Text = "作者: ";
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
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { Id, Title, Author, Publisher, PublishDate, AgeRating });
            dgvBooks.Location = new Point(12, 185);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(560, 308);
            dgvBooks.TabIndex = 9;
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
            Title.Width = 130;
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
            AgeRating.Width = 70;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(368, 499);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 50);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(117, 499);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 50);
            btnSave.TabIndex = 17;
            btnSave.Text = "確定";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // BorrowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dgvBooks);
            Controls.Add(groupBox1);
            Controls.Add(lblName);
            Controls.Add(label2);
            Controls.Add(txtIdNumber);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "BorrowForm";
            Text = "借書";
            KeyDown += Form_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdNumber;
        private Label label2;
        private Label lblName;
        private Label label3;
        private Label label4;
        private TextBox txtBookId;
        private Label lblAgeRating;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private DataGridView dgvBooks;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Publisher;
        private DataGridViewTextBoxColumn PublishDate;
        private DataGridViewTextBoxColumn AgeRating;
        private Button btnCancel;
        private Button btnSave;
        private Label lblPublisher;
        private Label lblPublishDate;
        private Label lblAuthor;
    }
}