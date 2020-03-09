using System;
namespace CSProject
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public Manager (string name) : base (name, managerHourlyRate)
        {
            
        }


        public override void CalculatePay()
        {
            base.CalculatePay();

            Allowance = 1000;

            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance;

            }       

        }


        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nmangerHourlyRate = " + managerHourlyRate
                + "\nHoursWorked = " + HoursWorked
                + "\nBasicPay = " + BasicPay
                + "\nAllowance = " + Allowance
                + "\nTotalPay = " + TotalPay;
        }

    }
}
