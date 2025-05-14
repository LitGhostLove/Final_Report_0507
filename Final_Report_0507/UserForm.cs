using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Final_Report_0507
{
    public partial class UserForm : Form
    {
        private List<User> users = new List<User>();

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            users = JsonStorage<User>.Load("users.json") ?? new List<User>();
            LoadUsers();
        }

        private void LoadUsers(List<User>? source = null)
        {
            dgvUsers.Rows.Clear();

            var listToShow = source ?? users;

            foreach (var user in listToShow)
            {
                int rowIndex = dgvUsers.Rows.Add();
                DataGridViewRow row = dgvUsers.Rows[rowIndex];

                row.Cells["chk"].Value = false;
                row.Cells["IdNumber"].Value = user.IdNumber;
                row.Cells["userName"].Value = user.Name;
                row.Cells["Birthday"].Value = user.Birthday.ToString("yyyy-MM-dd");
                row.Cells["Email"].Value = user.Email;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new UserEditForm(users);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                users.Add(dialog.UserData);
                JsonStorage<User>.Save("users.json", users);
                LoadUsers();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedUsers();
            if (selected.Count != 1)
            {
                MessageBox.Show("請選擇一筆資料進行編輯");
                return;
            }

            var dialog = new UserEditForm(users, selected[0]);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var index = users.FindIndex(u => u.IdNumber == selected[0].IdNumber);
                users[index] = dialog.UserData;
                JsonStorage<User>.Save("users.json", users);
                LoadUsers();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedUsers();
            if (selected.Count == 0)
            {
                MessageBox.Show("請先選擇要刪除的使用者");
                return;
            }

            var books = JsonStorage<Book>.Load("books.json") ?? new List<Book>();

            foreach (var user in selected)
            {
                bool hasUnreturnedBooks = books.Any(b => b.Borrower == user.IdNumber);

                if (hasUnreturnedBooks)
                {
                    MessageBox.Show($"使用者 {user.Name} 尚有書籍未歸還，無法刪除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show("確定要刪除選取的使用者？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                users = users.Except(selected).ToList();
                JsonStorage<User>.Save("users.json", users);
                LoadUsers();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            var filtered = users.Where(u =>
                u.IdNumber.ToLower().Contains(keyword) ||
                u.Name.ToLower().Contains(keyword) ||
                u.Email.ToLower().Contains(keyword) ||
                u.Birthday.ToString("yyyy-MM-dd").Contains(keyword)
            ).ToList();

            LoadUsers(filtered);
        }

        private List<User> GetSelectedUsers()
        {
            var selected = new List<User>();
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["chk"].Value);
                if (isChecked)
                {
                    string id = row.Cells["IdNumber"].Value?.ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        var user = users.FirstOrDefault(u => u.IdNumber == id);
                        if (user != null)
                            selected.Add(user);
                    }
                }
            }
            return selected;
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
