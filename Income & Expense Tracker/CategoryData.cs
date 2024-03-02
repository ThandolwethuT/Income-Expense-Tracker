﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Income___Expense_Tracker
{
    internal class CategoryData
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell-User\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public int ID { set; get; }
        public string Category { set; get; }

        public string Type { set; get; }

        public string Status { set; get; }

        public string Date {  set; get; }

        public List<CategoryData> categoryListData()
        {
            List<CategoryData> listData = new List<CategoryData>();

            using(SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string selectData = "SELECT * FROM categories";

                using(SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CategoryData cData = new CategoryData();
                        cData.ID = (int)reader["ID"];
                        cData.Category = reader["category"].ToString();
                        cData.Type = reader["Type"].ToString();
                        cData.Status = reader["status"].ToString();
                        cData.Date = ((DateTime)reader["date_insert"]).ToString("dd-MM-yyyy");

                        listData.Add(cData);
                    }
                        
                }
            }
            return listData;
        }
    }
}
