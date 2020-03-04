using BondCalculatorData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramData.Models
{
    public class Calculation
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Principle { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double Deposit { get; set; } = 0;

        [Required]
        public double Rate { get; set; }

        [Required]
        public double BondTerm { get; set; } = 0;

        public DateTime CalculationDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double MonthlyPayment { get; set; } = 0;

        //public IEnumerable<AmotValue> AmotValues { get; set; }

    }
}