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
        private List<User> users = new List<User>();

        public BookForm()
        {
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            cmbSearchField.SelectedIndex = 0;
            LoadBooks();
        }

        private async void LoadBooks()
        {
            books = await JsonStorage<Book>.LoadAsync();
            users = await JsonStorage<User>.LoadAsync();

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

        private async void btnDelete_Click(object sender, EventArgs e)
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

                await JsonStorage<Book>.SaveAsync(books);
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
                        Borrower = row.Cells["Borrower"].Value?.ToString() ?? ""
                    });
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

        private async void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newBooks = new List<Book>();

                        using (var workbook = new ClosedXML.Excel.XLWorkbook(ofd.FileName))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                            int maxId = books.Count > 0 ? books.Max(b => b.Id) : 0;

                            foreach (var row in rows)
                            {
                                var book = new Book
                                {
                                    Id = ++maxId,
                                    Title = row.Cell(1).GetString(),
                                    Author = row.Cell(2).GetString(),
                                    Publisher = row.Cell(3).GetString(),
                                    PublishDate = DateTime.Parse(row.Cell(4).GetString()),
                                    AgeRating = row.Cell(5).GetString(),
                                    Borrower = ""
                                };
                                newBooks.Add(book);
                            }
                        }

                        books.AddRange(newBooks);
                        await JsonStorage<Book>.SaveAsync(books);
                        LoadBooks();
                        MessageBox.Show("匯入成功！");
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("無法讀取 Excel 檔案，請確認檔案是否已關閉，或未被其他程式使用。", "檔案被佔用", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"發行日格式錯誤，請確認 Excel 中的日期格式。\n\n錯誤訊息：{ex.Message}", "資料格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"匯入時發生錯誤：{ex.Message}", "匯入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"books_{timestamp}.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Books");

                            // 標題列
                            worksheet.Cell(1, 1).Value = "編號";
                            worksheet.Cell(1, 2).Value = "書名";
                            worksheet.Cell(1, 3).Value = "作者";
                            worksheet.Cell(1, 4).Value = "出版社";
                            worksheet.Cell(1, 5).Value = "發行日";
                            worksheet.Cell(1, 6).Value = "分級";
                            worksheet.Cell(1, 7).Value = "借書人";
                            worksheet.Cell(1, 8).Value = "狀態";

                            // 寫入資料
                            for (int i = 0; i < books.Count; i++)
                            {
                                var book = books[i];
                                worksheet.Cell(i + 2, 1).Value = book.Id;
                                worksheet.Cell(i + 2, 2).Value = book.Title;
                                worksheet.Cell(i + 2, 3).Value = book.Author;
                                worksheet.Cell(i + 2, 4).Value = book.Publisher;
                                worksheet.Cell(i + 2, 5).Value = book.PublishDate.ToString("yyyy-MM-dd");
                                worksheet.Cell(i + 2, 6).Value = book.AgeRating;
                                worksheet.Cell(i + 2, 7).Value = GetUserNameById(book.Borrower);
                                worksheet.Cell(i + 2, 8).Value = book.Status;
                            }

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("匯出成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("無法寫入檔案，請確認該檔案未被開啟或使用中。", "檔案被佔用", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"匯出時發生錯誤：{ex.Message}", "匯出失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportTemplate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "匯入格式範本.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("匯入範本");

                            // 標題列
                            worksheet.Cell(1, 1).Value = "書名";
                            worksheet.Cell(1, 2).Value = "作者";
                            worksheet.Cell(1, 3).Value = "出版社";
                            worksheet.Cell(1, 4).Value = "發行日";
                            worksheet.Cell(1, 5).Value = "分級";

                            // 範例資料
                            worksheet.Cell(2, 1).Value = "C# 從入門到實務";
                            worksheet.Cell(2, 2).Value = "王小明";
                            worksheet.Cell(2, 3).Value = "資訊出版社";
                            worksheet.Cell(2, 4).Value = "2023-05-01";
                            worksheet.Cell(2, 5).Value = "普遍級";

                            worksheet.Range("A1:E1").Style.Font.Bold = true;
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("匯入格式範本已建立成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"建立範本時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
