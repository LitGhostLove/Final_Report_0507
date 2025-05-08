namespace Final_Report_0507
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblTitle = new Label();
            btnBorrow = new Button();
            btnReturn = new Button();
            btnBook = new Button();
            btnUser = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft JhengHei UI", 30F);
            lblTitle.Location = new Point(21, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(342, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "明新資工借書系統";
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(27, 102);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(150, 50);
            btnBorrow.TabIndex = 1;
            btnBorrow.Text = "借書";
            btnBorrow.UseVisualStyleBackColor = true;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(207, 102);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(150, 50);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "還書";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(27, 184);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(150, 50);
            btnBook.TabIndex = 3;
            btnBook.Text = "書籍管理";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // btnUser
            // 
            btnUser.Location = new Point(207, 184);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(150, 50);
            btnUser.TabIndex = 4;
            btnUser.Text = "用戶管理";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(btnUser);
            Controls.Add(btnBook);
            Controls.Add(btnReturn);
            Controls.Add(btnBorrow);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "明新資工借書系統";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnBorrow;
        private Button btnReturn;
        private Button btnBook;
        private Button btnUser;
    }
}
