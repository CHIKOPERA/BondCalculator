using System;
using System.Collections.Generic;
using System.Text;

namespace BondCalculatorData.Models
{
    public class AmotValue
    {
        public double Year { get; set; }
        public string IntPayment { get; set; }
        public string CapitalPayment { get; set; }
        public AmotValue()
        {

        }
        public AmotValue(double year, string intr, string cap)
        {
            Year = year;
            IntPayment = intr;
            CapitalPayment = cap;
        }
    }
}
