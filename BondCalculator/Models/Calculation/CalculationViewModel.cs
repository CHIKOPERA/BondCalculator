using BondCalculatorData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BondCalculator.Models.Calculation
{
    public class CalculationViewModel
    {
        [Required(ErrorMessage = "Calculation name is requires")]
        [Display(Name = "Calculation Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Loan amount is requires")]
        [Display(Name = "Loan Amount")]
        public double Principle { get; set; }

        [Required]
        [Display(Name = "Initial Deposit")]
        public double Deposit { get; set; } = 0;

        [Required]
        [Display(Name = "Interest Rate")]
        public double Rate { get; set; }

        [Required]
        [Display(Name = "Bond Payment Period")]
        public double BondTerm { get; set; } = 0;

        public DateTime CalDate { get; set; } = DateTime.Now;
        public double MonthlyPayment { get; set; } = 0;

        public IEnumerable<ProgramData.Models.Calculation> Calculations { get; set; }
        public IEnumerable<AmotValue> AmotValues { get; set; } 
    }
}