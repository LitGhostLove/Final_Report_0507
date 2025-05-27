using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private async void txtIdNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string idNumber = txtIdNumber.Text.Trim();
                var users = await JsonStorage<User>.LoadAsync();
                var user = users.FirstOrDefault(u => u.IdNumber == idNumber);

                if (user != null)
                {
                    lblName.Text = user.Name;
                    txtIdNumber.Enabled = false;
                    groupBox1.Visible = true;
                    txtBookId.Focus();
                    currentUserId = user.IdNumber;
                    currentUser = user;
                }
                else
                {
                    MessageBox.Show("用戶不存在！");
                    txtIdNumber.SelectAll();
                    txtIdNumber.Focus();
                }
            }
        }

        private async void txtBookId_KeyDown(object sender, KeyEventArgs e)
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

                books = await JsonStorage<Book>.LoadAsync();
                var book = books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    MessageBox.Show("查無此書！");
                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                if (book.AgeRating == "限制級" && CalculateAge(currentUser.Birthday) < 18)
                {
                    MessageBox.Show("該書籍為限制級，您的年齡暫時無法借閱！");
                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(book.Borrower))
                {
                    if (!string.IsNullOrEmpty(book.ReservationUserId))
                    {
                        if (book.ReservationUserId == currentUserId)
                        {
                            MessageBox.Show("您已預約過此書！");
                        }
                        else
                        {
                            MessageBox.Show("該書籍已被借出且有他人預約！");
                        }
                    }
                    else
                    {
                        if (book.Borrower != currentUserId)
                        {
                            var result = MessageBox.Show("該書籍已被借出！您要預約嗎？", "預約提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                book.ReservationUserId = currentUserId;
                                await JsonStorage<Book>.SaveAsync(books);
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
                        else
                        {
                            MessageBox.Show("該書籍已被您借閱。");
                        }
                    }

                    txtBookId.SelectAll();
                    txtBookId.Focus();
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(book.ReservationUserId))
                    {
                        if (book.ReservationUserId == currentUserId)
                        {
                            book.ReservationUserId = null;
                        }
                        else
                        {
                            MessageBox.Show("該書籍已有他人預約！");
                            txtBookId.SelectAll();
                            txtBookId.Focus();
                            return;
                        }
                    }
                }

                // 顯示書籍資訊
                lblAuthor.Text = book.Author;
                lblPublisher.Text = book.Publisher;
                lblPublishDate.Text = book.PublishDate.ToShortDateString();
                lblAgeRating.Text = book.AgeRating;

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string idNumber = txtIdNumber.Text.Trim();
            var allBooks = await JsonStorage<Book>.LoadAsync();

            foreach (var borrowedBook in selectedBooks)
            {
                var target = allBooks.FirstOrDefault(b => b.Id == borrowedBook.Id);
                if (target != null)
                {
                    target.Borrower = idNumber;
                }
            }

            await JsonStorage<Book>.SaveAsync(allBooks);
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
