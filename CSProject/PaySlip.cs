using System;
namespace CSProject
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsofYear
        {
            JAN = 1, FEB = 2, MAR = 3, APR = 4, MAY = 5, JUN = 6, JUL = 7, AUG = 8, SEP = 9, OCT = 10, NOV = 11, DEC = 12
        }

        public PaySlip (int Month, int Year)
        {
            month = Month;
            year = Year;
        }

        public void GeneratePaySlip(List<Staff>myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {

            }
        }
    }
}
