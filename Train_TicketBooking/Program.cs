using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using TRAIN_TICKET_MANAGEMENT_SYSTEM;
using Train_TicketBooking;

namespace MyApp
{
    internal class Program
    {
        public int train_no;
        public string cmp_type;
        public string book_date;
        public int tic_cnt;
        static void Main(string[] args)
        {
            Program p = new Program();
            Manipulations mn = new Manipulations();
            Management mg = new Management();

            Console.WriteLine("Enter 1 for Signup 2 for Login: ");
            int signlogn = Convert.ToInt32(Console.ReadLine());

            if(signlogn == 1) 
            {
                Console.WriteLine("Enter Username: ");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Mobile Number: ");
                long mnumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Password: ");
                string pword = Console.ReadLine();
                Login ln = new Login(uname, pword,mnumber);
                ln.UserInfo();
                ln.InsertVal();

            }
            else
            {
                Console.WriteLine("Enter Username: ");
                string uname = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string pword = Console.ReadLine();
                Login ln = new Login(uname, pword);
                ln.check_user();
            }

/*
            Console.Write("Enter passanger Username : ");
            string name = Console.ReadLine();
            Console.Write("Enter password : ");
            string pass = Console.ReadLine();

            */
          //  Login ln=new Login(name,pass);
           

            


            Console.WriteLine("\nWelcome to NAASA Train Ticket Booking System\n\n");
            mg.Train_Details();


            Console.Write("\nDo you want to book ticket (yes/no) : ");
            string wish = Console.ReadLine();

            if (wish.ToLower() == "yes")
            {

                Console.Write("Select the train ID you want to book : ");
                p.train_no = Convert.ToInt32(Console.ReadLine());

                Console.Write("Select the compartment you want to book (AC/Sleeper/Seater) : ");
                p.cmp_type = Console.ReadLine();

                Console.Write("Enter the date you want to book your ticket (yyyy-mm-dd): ");
                p.book_date = Console.ReadLine();



               
                Console.Write("How many tickets you want to book : ");

                p.tic_cnt = Convert.ToInt32(Console.ReadLine());
                  Console.WriteLine("-----------------------------------------------------------------");
                int seat_no = 1;
                for (int i = 0; i < p.tic_cnt; i++)
                {
                    Console.WriteLine($"-------Enter the details of {i + 1} passanger : --------");
                    mg.Pass_Insert(p.train_no, p.cmp_type, p.book_date, seat_no);
                    seat_no++;
                }
                mg.tick();
                int amt = 0;
                if( p.cmp_type.ToLower()=="ac")
                {
                    amt = 850;
                }
                else if (p.cmp_type.ToLower() == "sleeper")
                {
                    amt = 500;
                }
                else if (p.cmp_type.ToLower() == "seater")
                {
                    amt = 220;
                }
                else
                {
                    Console.WriteLine("");
                }
                    Console.WriteLine(  "Total Amount to be paid : "+p.tic_cnt*amt);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Thank you for visting our site !!!!!!");
            }
          



            //Console.WriteLine("Passenger details inserted successfully!!!");
        }
    }
}