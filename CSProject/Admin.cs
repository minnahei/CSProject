using System;
namespace CSProject
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin (string name) : base (name, adminHourlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nadminHourlyRate = " + adminHourlyRate
                + "\nHoursWorked = " + HoursWorked
                + "\nBasicPay = " + BasicPay
                + "\novertimeRate = " + overtimeRate
                + "\nTotalPay = " + TotalPay;
        }
    }
}
