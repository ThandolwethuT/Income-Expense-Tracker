using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Income___Expense_Tracker
{
    internal class ExpenseData
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell-User\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public int ID { set; get; }
        public string Category { set; get; }

        public string Description { set; get; }

        public string Item { set; get; }

        public string Cost { set; get; }

        public string DateExpense { set; get; }

        public List<ExpenseData> ExpenseListData()
        {
            List<ExpenseData> listData = new List<ExpenseData>();

            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                conn.Open();

                string selectData = "SELECT * FROM expenses";

                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ExpenseData eData = new ExpenseData();
                        eData.ID = (int)reader["ID"];
                        eData.Category = reader["Category"].ToString();
                        eData.Item = reader["Item"].ToString();
                        eData.Cost = reader["cost"].ToString();
                        eData.Description = reader["Description"].ToString();
                        eData.DateExpense = ((DateTime)reader["date_expense"]).ToString("dd-MM-yyyy");

                        listData.Add(eData);
                    }
                }
            }
            return listData;
        }
    }
}
