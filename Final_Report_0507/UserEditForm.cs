using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Final_Report_0507
{
    public partial class UserEditForm : Form
    {
        public User UserData { get; private set; }
        private List<User> existingUsers;
        private bool isEditing;

        // 新增用
        public UserEditForm(List<User> allUsers)
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
            existingUsers = allUsers;
            isEditing = false;
        }

        // 編輯用
        public UserEditForm(List<User> allUsers, User existing) : this(allUsers)
        {
            txtId.Text = existing.IdNumber;
            txtId.Enabled = false;  // 編輯時禁止修改ID
            txtName.Text = existing.Name;
            dtpBirthday.Value = existing.Birthday;
            txtEmail.Text = existing.Email;
            isEditing = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(name) ||
                !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("請輸入正確的資料");
                return;
            }

            // 若為新增，檢查是否重複
            if (!isEditing && existingUsers.Any(u => u.IdNumber == id))
            {
                MessageBox.Show("該學號已存在！");
                return;
            }

            UserData = new User
            {
                IdNumber = id,
                Name = name,
                Birthday = dtpBirthday.Value,
                Email = email
            };

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("確定要取消嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                btnCancel_Click(sender, EventArgs.Empty);
            }
        }
    }
}
