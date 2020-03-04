using BondCalculator.Models.Calculation;
using BondCalculatorData;
using Microsoft.AspNetCore.Mvc;
using ProgramData.Models;
using System;

namespace BondCalculator.Controllers
{
    public class CalculationController : Controller
    {
        public ICalculations _calculation;

        public CalculationController(ICalculations calculation)
        {
            _calculation = calculation;
        }

        public IActionResult Index()
        {
            var model = new CalculationViewModel();
            model.Calculations = _calculation.GetAll();

            return View(model);
        }

        [HttpPost]  
        public IActionResult Index(CalculationViewModel calculation)
        {
            var cal = new Calculation
            {
                Name = calculation.Name,
                BondTerm = calculation.BondTerm,
                Principle = calculation.Principle,
                Deposit = calculation.Deposit,
                Rate = calculation.Rate,
            };
            double monthlyPayment = Math.Round(_calculation.CalculateMonthlyPayment(cal), 2);
            cal.MonthlyPayment = calculation.MonthlyPayment = monthlyPayment;

            _calculation.Add(cal);
            calculation.Calculations = _calculation.GetAll();
            calculation.AmotValues = _calculation.GetAmotValues(cal);
            return View(calculation);
        }
    }
}