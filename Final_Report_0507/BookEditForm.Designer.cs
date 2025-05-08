namespace Final_Report_0507
{
    partial class BookEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtId = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            dtpPublishDate = new DateTimePicker();
            cmbAgeRating = new ComboBox();
            label6 = new Label();
            txtPublisher = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
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
            label1.Text = "編號: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F);
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "書名: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F);
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 0;
            label3.Text = "作者: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F);
            label4.Location = new Point(12, 216);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 0;
            label4.Text = "出版社: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F);
            label5.Location = new Point(12, 285);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 0;
            label5.Text = "發行日: ";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(12, 32);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 101);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(260, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(12, 170);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(260, 23);
            txtAuthor.TabIndex = 2;
            // 
            // dtpPublishDate
            // 
            dtpPublishDate.Location = new Point(12, 308);
            dtpPublishDate.Name = "dtpPublishDate";
            dtpPublishDate.Size = new Size(200, 23);
            dtpPublishDate.TabIndex = 4;
            // 
            // cmbAgeRating
            // 
            cmbAgeRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgeRating.FormattingEnabled = true;
            cmbAgeRating.Items.AddRange(new object[] { "普遍級", "限制級" });
            cmbAgeRating.Location = new Point(163, 32);
            cmbAgeRating.Name = "cmbAgeRating";
            cmbAgeRating.Size = new Size(60, 23);
            cmbAgeRating.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F);
            label6.Location = new Point(163, 9);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 0;
            label6.Text = "分級: ";
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(12, 239);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(260, 23);
            txtPublisher.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(22, 399);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 50);
            btnSave.TabIndex = 6;
            btnSave.Text = "儲存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(163, 399);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 461);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPublisher);
            Controls.Add(label6);
            Controls.Add(cmbAgeRating);
            Controls.Add(dtpPublishDate);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "BookEditForm";
            Text = "書籍編輯器";
            Load += BookEditForm_Load;
            KeyDown += Form_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtId;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private DateTimePicker dtpPublishDate;
        private ComboBox cmbAgeRating;
        private Label label6;
        private TextBox txtPublisher;
        private Button btnSave;
        private Button btnCancel;
    }
}