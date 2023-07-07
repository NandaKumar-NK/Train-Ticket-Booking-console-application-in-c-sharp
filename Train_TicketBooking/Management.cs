using MyApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAIN_TICKET_MANAGEMENT_SYSTEM
{
    internal class Management : Program
    {
        SqlConnection con;
        SqlCommand cmd, cmd1, cmd2;
        SqlDataReader rd;
        Manipulations mn = new Manipulations();


        //Passanger Details Insertion

        public void Pass_Insert(int train_no, string cmp_type, string book_date, int seat_no)
        {
            try
            {
                Console.Write("Enter passanger name : ");
                string name = Console.ReadLine();

                Console.Write("Enter passanger phone number: ");
                long ph_no = Convert.ToInt64(Console.ReadLine());
                con = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
                con.Open();
                //command for passenger insert
                cmd = new SqlCommand($"INSERT INTO Passanger_details(passanger_name,mobile_no) values('{name}',{ph_no})", con);
                cmd.ExecuteNonQuery();
                // command for count
                cmd2 = new SqlCommand($"Pssid_cnt", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
              //  int passn_id = (int)cmd.Parameters["@cnt"].Value;
                cmd2.Parameters.Add("@cnt", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                cmd2.ExecuteNonQuery();
                int cnt = (int)cmd2.Parameters["@cnt"].Value;
               // Console.WriteLine("Passid "+cnt);
               // Console.WriteLine("train no"+train_no);
              cmd1 = new SqlCommand($"INSERT INTO booking_details(train_id,compartment_type,seat_no,t_date,pass_id) values({train_no},'{cmp_type}',{seat_no},'{book_date}',{cnt})", con);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex.Message);
            }
            finally { con.Close(); }
        }
        //Fetching Train Details
        public void Train_Details()
        {
            try
            {
                Console.WriteLine("-------Train Details----------");
                con = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
                con.Open();
                cmd = new SqlCommand($"SELECT * FROM train_details", con);
                rd = cmd.ExecuteReader();
                if (rd.HasRows == null)
                {
                    Console.WriteLine("There is no trains available now!!!!!");
                }
                else
                {
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd["train_id"]}  {rd["train_name"]}  {rd["sources"]}  {rd["destination"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Happy journey :)");
                Console.WriteLine("-----------------------------------------------------------------");


            }
        }

        public void tick()
        {
            try
            {
                con = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
                con.Open();
                Program p = new Program();
                cmd2 = new SqlCommand($"Pssid_cnt", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                //  int passn_id = (int)cmd.Parameters["@cnt"].Value;
                cmd2.Parameters.Add("@cnt", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                cmd2.ExecuteNonQuery();
                int cnt = (int)cmd2.Parameters["@cnt"].Value;
                Console.Write("Enter total ticket : ");

                int ti =Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------------------");

                for (int i = 0; i <ti; i++)
                {
                    booking_Details(cnt);
                    cnt--;
                }
                Console.WriteLine("Ticket booked successfully!!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close() ;
            }
        }

        public void booking_Details(int passn_id)
        {
            try
            {

                con = new SqlConnection("data source = LAPTOP-6JOEM91O\\SQLEXPRESS01;initial catalog=Train_TicketBooking; integrated security=True;");
                con.Open();
                cmd = new SqlCommand($"SELECT * FROM booking_details where pass_id={passn_id}", con);
                rd = cmd.ExecuteReader();
                if (rd.HasRows == null)
                {
                    Console.WriteLine("you not booked a ticket!!!!!");
                }
                else
                {
                    while (rd.Read())
                    {
                        Console.WriteLine($" {rd["ticket_id"]} {rd["train_id"]} {rd["compartment_type"]}  {rd["seat_no"]} {rd["T_date"]} {rd["pass_id"]}");
                        // Console.WriteLine($"{rd["train_id"]}  {rd["cmp_type"]}  {rd["seat_no"]}  {rd["book_date"]} {rd["cnt"]} ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong : " + ex.Message);
            }
            finally
            {
                con.Close();
             //   Console.WriteLine("Happy journey :)");
            }
        }
    }
}