using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TableID { get; set; }
        public int Amount { get; set; }
        public float Discount { get; set; }
        public float Tax { get; set; }
        public bool Status { get; set; }
        public DateTime CheckoutDate { get; set; }
        public string Account { get; set; }

    }

    public class BillDA
    {
        public List<Bill> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_GetAll;

            SqlDataReader reader = command.ExecuteReader();
            List<Bill> list = new List<Bill>();
            while (reader.Read())
            {
                Bill Bill = new Bill();
                Bill.ID = Convert.ToInt32(reader["ID"]);
                Bill.Name = reader["Name"].ToString();
                Bill.TableID = Convert.ToInt32(reader["TableID"]);
                Bill.Amount = Convert.ToInt32(reader["Amount"]);
                Bill.Discount = float.Parse(reader["Discount"].ToString());
                Bill.Tax = float.Parse(reader["Tax"].ToString());
                Bill.Status = Convert.ToBoolean(reader["Status"]);
                Bill.CheckoutDate = Convert.ToDateTime(reader["CheckoutDate"]);
                Bill.Account = reader["Account"].ToString();
                list.Add(Bill);
            }
            sqlConn.Close();
            return list;
        }
    }
}
