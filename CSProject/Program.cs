using System;
using System.Collections.Generic;
using static System.Console;

namespace CSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0, year = 0;

            while (year == 0)
            {
                Write("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "Please try again");
                }
            }

            while (month == 0)
            {
                Write("Please enter the month: ");

                try
                {
                    month = Convert.ToInt32(ReadLine());

                    if (month < 1 || month > 12)
                    {
                        WriteLine("Month must be between from 1 to 12. Please try again.");
                        month = 0;
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "Please try again.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i< myStaff.Count; i++)
            {
                try
                {
                    //Retrieve the hours worked for the current staff
                    Write("\nEnter hours worked for {0}: ", myStaff[i].HoursWorked);
                    myStaff[i].HoursWorked = Convert.ToInt32(ReadLine());

                    //Calculate the pay and write it to the screen
                    myStaff[i].CalculatePay();
                    WriteLine(myStaff[i]);
                }
                catch (Exception e)

                {
                    WriteLine(e.Message);
                    //Decrement the counter so we process the same staff again
                    i--;
                }
            }

            //Create a pay slip object to output the pay slips and summary
            PaySlip ps = new PaySlip (int month, int year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Read();

        }
    }
}
