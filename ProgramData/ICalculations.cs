using BondCalculatorData.Models;
using ProgramData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BondCalculatorData
{
    public interface ICalculations
    {
        void Add(Calculation calculation);
        IEnumerable<Calculation> GetAll();
        double GetMonthlyPayment(int id);
        DateTime GetCalculationDate(int id);
        double CalculateMonthlyPayment(Calculation calculation);
        Calculation GetById(int id);
        double GetPrinciple(int id);
        double GetRate(int id);
        double GetDeposit(int id);
        Calculation GetLastCalculation();
        IEnumerable<AmotValue> GetAmotValues(Calculation calculation);

    }
}
