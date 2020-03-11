using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CSProject
{
    class PaySlip
    {
        //Fields
        private int month;
        private int year;

        //Enum (private by default inside a class)
        enum MonthsOfYear { JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        //Constructor
        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        //Methods
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    //Print the element # "month" from the MonthsOfYear enum
                    sw.WriteLine("PAY SLIP FOR {0} {1}", (MonthsOfYear)month, year);

                    //Generate a string by repeating the '=' char 25 times.
                    sw.WriteLine(new String('=', 25));
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");

                    //Use [C]urrency format for the BasicPay amount.
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                    //Depending on the typeof Staff class being processed, cast f into an
                    //object of that type, so we can access the properties of that class.
                    if (f.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                    else if (f.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime Pay: {0:C}", ((Admin)f).Overtime);

                    sw.WriteLine("");
                    sw.WriteLine(new String('=', 25));
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine(new String('=', 25));

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            string path = "summary.txt";

           

            //Retrieve a list of staff with less than 10 hours.
            var result =
                from st in myStaff
                where st.HoursWorked < 10
                orderby st.NameOfStaff
                select new { st.NameOfStaff, st.HoursWorked };

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours for {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("");

                foreach (var f in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);
                }
                sw.WriteLine(new String('=', 25));

                sw.Close();
            }
        }

        public override string ToString()
        {
            return "\nMonth = " + month
                + "\nYear = " + year;
        }
    }
}
