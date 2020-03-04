using BondCalculatorData;
using BondCalculatorData.Models;
using Microsoft.EntityFrameworkCore;
using ProgramData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BondCalculatorServices
{
    public class CalculationService : ICalculations
    {
        private BondCalculatorDbContext _context;

        public Calculation GetLastCalculation() => _context.Calculations
            .OrderBy(a => a.CalculationDate)
            .FirstOrDefault();

        public CalculationService(BondCalculatorDbContext context)
        {
            _context = context;
        }
        public Calculation GetById(int id) => _context.Calculations
            .FirstOrDefault(cal => cal.Id == id);

        public void Add(Calculation calculation)
        {
            calculation.MonthlyPayment = CalculateMonthlyPayment(calculation);
            calculation.CalculationDate = DateTime.Now;
            _context.Add(calculation);
            _context.SaveChanges();
        }


        public IEnumerable<Calculation> GetAll() => _context.Calculations;

        public DateTime GetCalculationDate(int id) => GetById(id).CalculationDate;

        public double GetMonthlyPayment(int id) => GetById(id).MonthlyPayment;
        public double CalculateMonthlyPayment(Calculation calculation)
        {
            double _intRate = calculation.Rate / 100 / 12;
            return ((_intRate * calculation.Principle) * (Math.Pow((1 + _intRate), (calculation.BondTerm * 12)))) / ((Math.Pow((1 + _intRate), (calculation.BondTerm * 12))) - 1);
        }

        public double GetPrinciple(int id) => GetById(id).Principle;

        public double GetRate(int id) => GetById(id).Rate;

        public double GetDeposit(int id) => GetById(id).Deposit;

        public IEnumerable<AmotValue> GetAmotValues(Calculation calculation) => SetAmrtizaitonValues(calculation);
        private IEnumerable<AmotValue> SetAmrtizaitonValues(Calculation calculation)
        {
            double month = 1;
            var list = new List<AmotValue>();
            double _intRate = calculation.Rate / 100 / 12;
            double _principle = calculation.Principle;

            while (_principle> 0)
            {
                month++;
                double monthlyInterest = _intRate * _principle;
                double capital = calculation.MonthlyPayment - monthlyInterest;

                string IntPay = $"{Math.Round(((monthlyInterest / calculation.MonthlyPayment) * 100), 0)}%";
                string CapPay = $"{ Math.Round(((capital / calculation.MonthlyPayment) * 100), 0) }%";

                if (month % 12 == 0)
                {
                    AmotValue amot = new AmotValue((month / 12), IntPay, CapPay);

                    list.Add(amot);
                }

                _principle -= capital;
            }
            return list;
        }
    }
}