using System;
using System.Windows.Forms;

namespace Income___Expense_Tracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            displayUsername();
        }

        public void displayUsername()
        {
            string getUsername = Form1.username;

            greetUser.Text = "Welcome, " + getUsername.Substring(0, 1).ToUpper() + getUsername.Substring(1);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        

        private void logoutBtn_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void categoryForm1_Load(object sender, EventArgs e)
        {

        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = true;
            categoryForm1.Visible = false;
            incomeForm1.Visible = false;
            expenseForm1.Visible = false;

            DashboardForm dForm = dashboardForm1 as DashboardForm;

            if(dForm != null)
            {
                dForm.refreshData();
            }
        }

        private void add_categoryBtn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            categoryForm1.Visible = true;
            incomeForm1.Visible = false;
            expenseForm1.Visible = false;

            CategoryForm cForm = categoryForm1 as CategoryForm;
            if (cForm != null)
            {
                cForm.refreshData();
            }
        }

        private void incomeBtn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            categoryForm1.Visible = false;
            incomeForm1.Visible = true;
            expenseForm1.Visible = false;

            incomeForm iForm = incomeForm1 as incomeForm;
            if (iForm != null)
            {
                iForm.refreshData();
            }
        }

        private void expensesBtn_Click(object sender, EventArgs e)
        {

            dashboardForm1.Visible = false;
            categoryForm1.Visible = false;
            incomeForm1.Visible = false;
            expenseForm1.Visible = true;

            ExpenseForm eForm = expenseForm1 as ExpenseForm;
            if (eForm != null)
            {
                eForm.refreshData();
            }
        }
    }
}
