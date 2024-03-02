using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Income___Expense_Tracker
{
    internal class incomeData
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell-User\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public int ID { set; get; }
        public string Category { set; get; }

        public string Description { set; get; }

        public string Item { set; get; }

        public string Cost { set; get; }

        public string DateIncome { set; get; }

        public List<incomeData> incomeListData()
        {
            List<incomeData> listData = new List<incomeData>();

            using(SqlConnection conn = new SqlConnection(stringConnection))
            {
                conn.Open();

                string selectData = "SELECT * FROM income";

                using(SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        incomeData iData = new incomeData();
                        iData.ID = (int)reader["ID"];
                        iData.Category = reader["Category"].ToString();
                        iData.Item = reader["Item"].ToString();
                        iData.Cost = reader["income"].ToString();
                        iData.Description = reader["Description"].ToString();
                        iData.DateIncome = ((DateTime)reader["date_income"]).ToString("dd-MM-yyyy");

                        listData.Add(iData);
                    }
                }
            }
            return listData;
        }
    }
}
