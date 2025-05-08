using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Final_Report_0507
{
    public partial class BorrowForm : Form
    {
        private List<Book> books;
        private List<Book> selectedBooks = new List<Book>();
        private string currentUserId = "";
        private User currentUser;

        public BorrowForm()
        {
            InitializeComponent();
        }

        private void txtIdNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string idNumber = txtIdNumber.Text.Trim();
                var users = JsonStorage<User>.Load("users.json");
                var user = users.FirstOrDefault(u => u.IdNumber == idNumber);

                if (user != null)
                {
                    lblName.Text = user.Name;
                    txtIdNumber.Enabled = false;
                    groupBox1.Visible = true;
                    txtBookId.Focus();
                    currentUserId = user.IdNumber;
                    currentUser = user; // 儲存當前用戶資訊以供年齡判斷
                }
                else
                {
                    MessageBox.Show("用戶不存在！");
                    txtIdNumber.SelectAll();
                    txtIdNumber.Focus();
                }
            }
        }

        private void txtBookId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string bookIdText = txtBookId.Text.Trim();
                if (!int.TryParse(bookIdText, out int bookId))
                {
                    MessageBox.Show("請輸入正確的書籍編號！");
                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                if (selectedBooks.Any(b => b.Id == bookId))
                {
                    MessageBox.Show("該書籍已經輸入過了！");
                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                books = JsonStorage<Book>.Load("books.json");
                var book = books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    MessageBox.Show("查無此書！");
                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                // 年齡限制判斷
                if (book.AgeRating == "限制級")
                {
                    int age = CalculateAge(currentUser.Birthday);
                    if (age < 18)
                    {
                        MessageBox.Show("該書籍為限制級，您的年齡暫時無法借閱！");
                        txtBookId.SelectAll();
                        txtBookId.Focus();
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(book.Borrower))
                {
                    if (!string.IsNullOrEmpty(book.ReservationUserId))
                    {
                        if (book.ReservationUserId == currentUserId)
                        {
                            MessageBox.Show("您已預約過此書，現在可借閱！");
                            book.ReservationUserId = null;
                        }
                        else
                        {
                            MessageBox.Show("該書籍已被借出且有他人預約！");
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("該書籍已被借出！您要預約嗎？", "預約提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            book.ReservationUserId = currentUserId;
                            JsonStorage<Book>.Save("books.json", books);
                            MessageBox.Show("預約成功！");
                        }
                        else
                        {
                            MessageBox.Show("已取消預約操作。");
                        }

                        txtBookId.SelectAll();
                        txtBookId.Focus();
                        return;
                    }

                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                // 顯示書籍資訊
                lblAuthor.Text = book.Author;
                lblPublisher.Text = book.Publisher;
                lblPublishDate.Text = book.PublishDate.ToShortDateString();
                lblAgeRating.Text = book.AgeRating;

                // 加入表格與已選書單
                dgvBooks.Rows.Add(book.Id, book.Title, book.Author, book.Publisher, book.PublishDate.ToShortDateString(), book.AgeRating);
                selectedBooks.Add(book);

                txtBookId.SelectAll();
                txtBookId.Focus();
            }
        }

        private int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age)) age--;
            return age;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idNumber = txtIdNumber.Text.Trim();
            var allBooks = JsonStorage<Book>.Load("books.json");

            foreach (var borrowedBook in selectedBooks)
            {
                var target = allBooks.FirstOrDefault(b => b.Id == borrowedBook.Id);
                if (target != null)
                {
                    target.Borrower = idNumber;
                }
            }

            JsonStorage<Book>.Save("books.json", allBooks);
            MessageBox.Show("借書成功！");
            this.Close();
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
