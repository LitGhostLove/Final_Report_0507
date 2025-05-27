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
    public partial class BookEditForm : Form
    {
        private Book? editingBook;
        private bool isEditMode = false;

        public BookEditForm()
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
            cmbAgeRating.SelectedIndex = 0;
        }

        public BookEditForm(Book book) : this()
        {
            editingBook = book;
            isEditMode = true;
        }

        private async void BookEditForm_Load(object sender, EventArgs e)
        {
            if (isEditMode && editingBook != null)
            {
                txtId.Text = editingBook.Id.ToString();
                txtTitle.Text = editingBook.Title;
                txtAuthor.Text = editingBook.Author;
                txtPublisher.Text = editingBook.Publisher;
                dtpPublishDate.Value = editingBook.PublishDate;
                cmbAgeRating.SelectedItem = editingBook.AgeRating;
            }
            else
            {
                // 取得新 ID
                var books = await JsonStorage<Book>.LoadAsync();
                int nextId = books.Count > 0 ? books[^1].Id + 1 : 1;

                txtId.Text = nextId.ToString();
            }

            txtId.ReadOnly = true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("請填寫完整資料");
                return;
            }

            var books = await JsonStorage<Book>.LoadAsync();

            if (isEditMode && editingBook != null)
            {
                var book = books.Find(b => b.Id == editingBook.Id);
                if (book != null)
                {
                    book.Title = txtTitle.Text;
                    book.Author = txtAuthor.Text;
                    book.Publisher = txtPublisher.Text;
                    book.PublishDate = dtpPublishDate.Value;
                    book.AgeRating = cmbAgeRating.SelectedItem.ToString()!;
                }
            }
            else
            {
                Book newBook = new Book
                {
                    Id = int.Parse(txtId.Text),
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Publisher = txtPublisher.Text,
                    PublishDate = dtpPublishDate.Value,
                    AgeRating = cmbAgeRating.SelectedItem.ToString()!
                };
                books.Add(newBook);
            }

            await JsonStorage<Book>.SaveAsync(books);
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
