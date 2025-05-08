namespace Final_Report_0507
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var borrowForm = new BorrowForm();
            borrowForm.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var returnForm = new ReturnForm();
            returnForm.ShowDialog();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm();
            bookForm.ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm();
            userForm.ShowDialog();
        }
    }
}
