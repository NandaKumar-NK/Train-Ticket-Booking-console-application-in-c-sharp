using System.Data.SqlClient;
using System;
using System.Drawing;

namespace Train_TicketBooking
{
    public class Login 
    {

        private string Username;
        private string Password;
        private long MOb;

        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public long Mobileno { get => MOb; set =>MOb = value; }

        public Login(string username, string password,long mob)
        {
            this.Username1 = username;
            this.Password1 = password;
            this.Mobileno=mob;
        }
        public Login(string username, string password)
        {
            this.Username1 = username;
            this.Password1 = password;
           
        }
        public void UserInfo()
        {

            Console.WriteLine("UserName: " + this.Username1);
            Console.WriteLine("Password: " + this.Mobileno);
            Console.WriteLine("Password: " + this.Password1);
        }

        public void InsertVal()
        {
            string qry = string.Format("insert into User_login values('{0}','{1}','{2}')", this.Username1,this.Mobileno, this.Password1);
            SqlConnection connect = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
            connect.Open();
            SqlCommand cmd = new SqlCommand(qry, connect);
            if (connect != null)
            {
                int n = cmd.ExecuteNonQuery();
                Console.WriteLine("inserted {0} ", n);
            }

        }
        public void check_user()
        {
            SqlConnection connect = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
            connect.Open();
            SqlCommand cmd = new SqlCommand("select name,password from User_login", connect);
            if (connect != null)
            {
                SqlDataReader s = cmd.ExecuteReader();
                while (s.Read())
                {
                    if (s[0].ToString() == Username1 && s[1].ToString() == Password1)
                    {
                        Console.WriteLine("Welcome to our Application {0}", s[0]);

                    }
                }
            }
            else
            {
                Console.WriteLine("Table is empty");
            }

        }

    }
}