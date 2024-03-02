using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Income___Expense_Tracker
{
    public partial class DashboardForm : UserControl
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell-User\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public DashboardForm()
        {
            InitializeComponent();

            incomeTodayIncome();
            incomeYesterdayIncome();
            incomeThisMonth();
            incomeThisYear();
            totalIncome();

            expensesToday();
            expensesYesterday();
            expensesYesterday();
            expensesThisYear();
            expensesThisMonth();
            totalExpenses();

        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            incomeTodayIncome();
            incomeYesterdayIncome();
            incomeThisMonth();
            incomeThisYear();
            totalIncome();

            expensesToday();
            expensesYesterday();
            expensesYesterday();
            expensesThisYear();
            expensesThisMonth();
            totalExpenses();
        }

        //INCOME
        public void incomeTodayIncome()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();

                string query = "SELECT SUM(income) FROM income WHERE date_income = @date_in";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal todayCost = Convert.ToDecimal(result);

                        income_today.Text = todayCost.ToString("C");
                    }
                    else
                    {
                        income_today.Text = "R0.00";
                    }

                }
            }
        }
        public void incomeYesterdayIncome()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                string query = "SELECT SUM(income) FROM income WHERE CONVERT(DATE, date_income) = DATEADD(day, DATEDIFF(day, 0, GETDATE()),-1)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yesterdayCost = Convert.ToDecimal(result);

                        income_yesterday.Text = yesterdayCost.ToString("C");
                    }
                    else
                    {
                        income_yesterday.Text = "R0.00";
                    }

                }

            }
        }

        public void incomeThisMonth()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(1);

                string query = "SELECT SUM(income) FROM income WHERE date_income >= @startMonth AND date_income <= @endMonth";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startMonth", startMonth);
                    command.Parameters.AddWithValue("@endMonth", endMonth);

                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal monthCost = Convert.ToDecimal(result);

                        income_thisMonth.Text = monthCost.ToString("C");
                    }
                    else
                    {
                        income_thisMonth.Text = "R0.00";
                    }

                }

            }
        }
        public void incomeThisYear()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startYear = new DateTime(today.Year, 1, 1);
                DateTime endYear = startYear.AddYears(1).AddDays(-1);

                string query = "SELECT SUM(income) FROM income WHERE date_income >= @startYear AND date_income <= @endYear";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startYear", startYear);
                    command.Parameters.AddWithValue("@endYear", endYear);
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yearCost = Convert.ToDecimal(result);

                        income_thisYear.Text = yearCost.ToString("C");
                    }
                    else
                    {
                        income_thisYear.Text = "R0.00";
                    }

                }

            }
        }

        //EXPENSES
        public void expensesToday()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();

                string query = "SELECT SUM(cost) FROM expenses WHERE date_expense = @date_ex";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@date_ex", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal todayCost = Convert.ToDecimal(result);

                        expenses_today.Text = todayCost.ToString("C");
                    }
                    else
                    {
                        expenses_today.Text = "R0.00";
                    }

                }
            }
        }
        public void expensesYesterday()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                string query = "SELECT SUM(cost) FROM expenses WHERE CONVERT(DATE, date_expense) = DATEADD(day, DATEDIFF(day, 0, GETDATE()),-1)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yesterdayCost = Convert.ToDecimal(result);

                        expenses_yesterday.Text = yesterdayCost.ToString("C");
                    }
                    else
                    {
                        expenses_yesterday.Text = "R0.00";
                    }

                }

            }
        }

        public void expensesThisMonth()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(1);

                string query = "SELECT SUM(cost) FROM expenses WHERE date_expense >= @startMonth AND date_expense <= @endMonth";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startMonth", startMonth);
                    command.Parameters.AddWithValue("@endMonth", endMonth);

                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal monthCost = Convert.ToDecimal(result);

                        expenses_thisMonth.Text = monthCost.ToString("C");
                    }
                    else
                    {
                        expenses_thisMonth.Text = "R0.00";
                    }

                }

            }
        }
        public void expensesThisYear()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startYear = new DateTime(today.Year, 1, 1);
                DateTime endYear = startYear.AddYears(1).AddDays(-1);

                string query = "SELECT SUM(cost) FROM expenses WHERE date_expense >= @startYear AND date_expense <= @endYear";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startYear", startYear);
                    command.Parameters.AddWithValue("@endYear", endYear);
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yearCost = Convert.ToDecimal(result);

                        expenses_thisYear.Text = yearCost.ToString("C");
                    }
                    else
                    {
                        expenses_thisYear.Text = "R0.00";
                    }

                }

            }
        }

        //TOTAL

        public void totalIncome()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();

                string query = "SELECT SUM(income) FROM income";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal totalCost = Convert.ToDecimal(result);

                        total_income.Text = totalCost.ToString("C");
                    }
                    else
                    {
                        total_income.Text = "R0.00";
                    }

                }
            }
        }

        public void totalExpenses()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();

                string query = "SELECT SUM(cost) FROM expenses";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal totalCost = Convert.ToDecimal(result);

                        total_expenses.Text = totalCost.ToString("C");
                    }
                    else
                    {
                        total_expenses.Text = "R0.00";
                    }

                }
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void expenses_today_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void total_expenses_Click(object sender, EventArgs e)
        {

        }

        private void total_income_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
