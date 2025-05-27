using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Final_Report_0507
{
    public partial class ReturnForm : Form
    {
        private List<Book> books;
        private User currentUser;

        public ReturnForm()
        {
            InitializeComponent();
        }

        private async void txtIdNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string idNumber = txtIdNumber.Text.Trim();
                var users = await JsonStorage<User>.LoadAsync();
                currentUser = users.FirstOrDefault(u => u.IdNumber == idNumber);

                if (currentUser == null)
                {
                    MessageBox.Show("用戶不存在！");
                    txtIdNumber.SelectAll();
                    txtIdNumber.Focus();
                    return;
                }

                lblName.Text = currentUser.Name;

                books = await JsonStorage<Book>.LoadAsync();
                var borrowedBooks = books
                    .Where(b => b.Borrower == idNumber)
                    .ToList();

                dgvBooks.Rows.Clear();

                if (!borrowedBooks.Any())
                {
                    MessageBox.Show("該用戶目前無借書紀錄！");
                    return;
                }

                foreach (var book in borrowedBooks)
                {
                    dgvBooks.Rows.Add(false, book.Id, book.Title, book.Author, book.Publisher, book.PublishDate.ToShortDateString(), book.AgeRating);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var selectedBookIds = new List<int>();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                if (isChecked)
                {
                    int bookId = Convert.ToInt32(row.Cells[1].Value);
                    selectedBookIds.Add(bookId);
                }
            }

            if (!selectedBookIds.Any())
            {
                MessageBox.Show("請選擇要歸還的書籍！");
                return;
            }

            var allBooks = await JsonStorage<Book>.LoadAsync();
            var users = await JsonStorage<User>.LoadAsync();

            foreach (var book in allBooks)
            {
                if (selectedBookIds.Contains(book.Id))
                {
                    book.Borrower = null;

                    // 如果有預約用戶，寄信通知但不清除 ReservationUserId
                    if (!string.IsNullOrWhiteSpace(book.ReservationUserId))
                    {
                        var reservedUser = users.FirstOrDefault(u => u.IdNumber == book.ReservationUserId);
                        if (reservedUser != null && !string.IsNullOrWhiteSpace(reservedUser.Email))
                        {
                            try
                            {
                                await EmailHelper.SendMailAsync(
                                    reservedUser.Email,
                                    "預約書籍可借閱通知",
                                    $"您預約的書籍《{book.Title}》已可借閱，請儘快辦理借書。"
                                );
                            }
                            catch
                            {
                                MessageBox.Show($"通知 {reservedUser.Name} 失敗！");
                            }
                        }
                    }
                }
            }

            await JsonStorage<Book>.SaveAsync(allBooks);
            MessageBox.Show("還書成功！");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("確定要取消嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
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
