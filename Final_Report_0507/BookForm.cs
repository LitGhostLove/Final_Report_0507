using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Report_0507
{
    public partial class BookForm : Form
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>(); // 載入用戶資料

        public BookForm()
        {
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            cmbSearchField.SelectedIndex = 0;
            LoadBooks();
        }

        private void LoadBooks()
        {
            books = JsonStorage<Book>.Load("books.json");
            users = JsonStorage<User>.Load("users.json");

            dgvBooks.DataSource = null;
            dgvBooks.Rows.Clear();
            foreach (var book in books)
            {
                int rowIndex = dgvBooks.Rows.Add();
                DataGridViewRow row = dgvBooks.Rows[rowIndex];

                string borrowerName = GetUserNameById(book.Borrower);

                row.Cells["chk"].Value = false;
                row.Cells["Id"].Value = book.Id;
                row.Cells["Title"].Value = book.Title;
                row.Cells["Author"].Value = book.Author;
                row.Cells["Publisher"].Value = book.Publisher;
                row.Cells["PublishDate"].Value = book.PublishDate.ToShortDateString();
                row.Cells["AgeRating"].Value = book.AgeRating;
                row.Cells["Borrower"].Value = borrowerName;
                row.Cells["Status"].Value = book.Status;
            }
        }

        private string GetUserNameById(string idNumber)
        {
            var user = users.FirstOrDefault(u => u.IdNumber == idNumber);
            return user?.Name ?? "";
        }

        private void TxtSearchKeyword_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchField.SelectedItem == null) return;

            string field = cmbSearchField.SelectedItem.ToString();
            string keyword = txtSearchKeyword.Text.Trim().ToLower();

            var result = books.Where(book =>
                (field == "編號" && book.Id.ToString().Contains(keyword)) ||
                (field == "書名" && book.Title.ToLower().Contains(keyword)) ||
                (field == "作者" && book.Author.ToLower().Contains(keyword)) ||
                (field == "出版社" && book.Publisher.ToLower().Contains(keyword)) ||
                (field == "發行日" && book.PublishDate.ToString("yyyy-MM-dd").Contains(keyword)) ||
                (field == "分級" && book.AgeRating.ToLower().Contains(keyword)) ||
                (field == "借書人" && GetUserNameById(book.Borrower).ToLower().Contains(keyword)) ||
                (field == "狀態" && book.Status.ToLower().Contains(keyword))
            ).ToList();

            dgvBooks.Rows.Clear();
            foreach (var book in result)
            {
                int rowIndex = dgvBooks.Rows.Add();
                DataGridViewRow row = dgvBooks.Rows[rowIndex];

                string borrowerName = GetUserNameById(book.Borrower);

                row.Cells["chk"].Value = false;
                row.Cells["Id"].Value = book.Id;
                row.Cells["Title"].Value = book.Title;
                row.Cells["Author"].Value = book.Author;
                row.Cells["Publisher"].Value = book.Publisher;
                row.Cells["PublishDate"].Value = book.PublishDate.ToString("yyyy-MM-dd");
                row.Cells["AgeRating"].Value = book.AgeRating;
                row.Cells["Borrower"].Value = borrowerName;
                row.Cells["Status"].Value = book.Status;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new BookEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedBooks();
            if (selected.Count != 1)
            {
                MessageBox.Show("請選擇一筆資料進行修改。");
                return;
            }

            var editForm = new BookEditForm(selected[0]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedBooks();
            if (selected.Count == 0)
            {
                MessageBox.Show("請選擇要刪除的資料。");
                return;
            }

            if (MessageBox.Show("確定刪除選取的書籍？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var book in selected)
                {
                    books.RemoveAll(b => b.Id == book.Id);
                }

                JsonStorage<Book>.Save("books.json", books);
                LoadBooks();
            }
        }

        private List<Book> GetSelectedBooks()
        {
            var selected = new List<Book>();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.Cells["chk"].Value != null && Convert.ToBoolean(row.Cells["chk"].Value))
                {
                    selected.Add(new Book
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                        Title = row.Cells["Title"].Value?.ToString() ?? "",
                        Author = row.Cells["Author"].Value?.ToString() ?? "",
                        Publisher = row.Cells["Publisher"].Value?.ToString() ?? "",
                        PublishDate = DateTime.TryParse(row.Cells["PublishDate"].Value?.ToString(), out DateTime date) ? date : DateTime.MinValue,
                        AgeRating = row.Cells["AgeRating"].Value?.ToString() ?? "",
                        Borrower = row.Cells["Borrower"].Value?.ToString() ?? "" // 若要寫入 JSON 時保留 ID，這裡就不能轉換成姓名
                    });
                }
            }

            return selected;
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true; // 防止嗶聲
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
