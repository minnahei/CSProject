﻿using System;
namespace CSProject
{
    public class Staff
    {
        // Fields
        private float hourlyRate;
        private int hWorked;

        //Properties
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }

            set
            {
                if (value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
            }
        }

        // Constructor
        public Staff (string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;

        }

        // Methods

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            BasicPay = hWorked * hourlyRate;

            TotalPay = BasicPay;

        }

        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nhourlyRate = " + hourlyRate
                + "\nhWorked = " + hWorked 
                + "\nBasicPay = " + BasicPay 
                + "\nTotalPay = " + BasicPay;
        }
    }
}
