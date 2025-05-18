namespace Final_Report_0507
{
    partial class BookForm
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookForm));
            cmbSearchField = new ComboBox();
            txtSearchKeyword = new TextBox();
            label1 = new Label();
            dgvBooks = new DataGridView();
            chk = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Publisher = new DataGridViewTextBoxColumn();
            PublishDate = new DataGridViewTextBoxColumn();
            AgeRating = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Borrower = new DataGridViewTextBoxColumn();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnExportExcel = new Button();
            btnImportExcel = new Button();
            btnImportTemplate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // cmbSearchField
            // 
            cmbSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchField.FormattingEnabled = true;
            cmbSearchField.Items.AddRange(new object[] { "編號", "書名", "作者", "出版社", "發行日" });
            cmbSearchField.Location = new Point(67, 8);
            cmbSearchField.Name = "cmbSearchField";
            cmbSearchField.Size = new Size(80, 23);
            cmbSearchField.TabIndex = 1;
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Location = new Point(153, 8);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(160, 23);
            txtSearchKeyword.TabIndex = 2;
            txtSearchKeyword.TextChanged += TxtSearchKeyword_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "搜尋: ";
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
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { chk, Id, Title, Author, Publisher, PublishDate, AgeRating, Status, Borrower });
            dgvBooks.Location = new Point(12, 37);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(560, 449);
            dgvBooks.TabIndex = 0;
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
            // Status
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Status.DefaultCellStyle = dataGridViewCellStyle5;
            Status.HeaderText = "狀態";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 50;
            // 
            // Borrower
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Borrower.DefaultCellStyle = dataGridViewCellStyle6;
            Borrower.HeaderText = "借閱用戶";
            Borrower.Name = "Borrower";
            Borrower.ReadOnly = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(35, 492);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 50);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(217, 492);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 50);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "編輯";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(399, 492);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 50);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "刪除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(399, 548);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(150, 50);
            btnExportExcel.TabIndex = 7;
            btnExportExcel.Text = "匯出";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnImportExcel
            // 
            btnImportExcel.Location = new Point(217, 548);
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(150, 50);
            btnImportExcel.TabIndex = 6;
            btnImportExcel.Text = "匯入";
            btnImportExcel.UseVisualStyleBackColor = true;
            btnImportExcel.Click += btnImportExcel_Click;
            // 
            // btnImportTemplate
            // 
            btnImportTemplate.Location = new Point(35, 548);
            btnImportTemplate.Name = "btnImportTemplate";
            btnImportTemplate.Size = new Size(150, 50);
            btnImportTemplate.TabIndex = 8;
            btnImportTemplate.Text = "製作匯入範本";
            btnImportTemplate.UseVisualStyleBackColor = true;
            btnImportTemplate.Click += btnImportTemplate_Click;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 611);
            Controls.Add(btnImportTemplate);
            Controls.Add(btnExportExcel);
            Controls.Add(btnImportExcel);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvBooks);
            Controls.Add(label1);
            Controls.Add(txtSearchKeyword);
            Controls.Add(cmbSearchField);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "BookForm";
            Text = "書籍資料";
            Load += BookForm_Load;
            KeyDown += Form_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSearchField;
        private TextBox txtSearchKeyword;
        private Label label1;
        private DataGridView dgvBooks;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridViewTextBoxColumn BorrowerId;
        private DataGridViewCheckBoxColumn chk;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Publisher;
        private DataGridViewTextBoxColumn PublishDate;
        private DataGridViewTextBoxColumn AgeRating;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Borrower;
        private Button btnExportExcel;
        private Button btnImportExcel;
        private Button btnImportTemplate;
    }
}