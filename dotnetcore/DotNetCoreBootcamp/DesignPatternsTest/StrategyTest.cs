﻿using System;
using DesignPatterns.Strategy.Example1;
using DesignPatterns.Strategy.LoanExample;
using Xunit;

namespace DesignPatternsTest
{
    public class StrategyTest
    {
        private readonly int RISK_RATING = 1;
        
        [Fact]
        public void Strategy_Loan_term_capital_should_return_136()
        {
            //arrange
            Loan termLoan = Loan.newTermLoan(10000.00, StartOfLoan(), Maturity(), RISK_RATING);
            termLoan.setOutstanding(10000.00);

            //act
            var result = termLoan.calcCapital();

            //assert
            Assert.Equal(20136, (int)result);
        }     

        [Fact]
        public void Strategy_Loan_revolver_roc_should_return_X() {
            //arrange
            Loan revolver = Loan.newRevolver(10000.00, StartOfLoan(), Expiry(), RISK_RATING);
            revolver.setOutstanding(2000.00);

            //act
            var result = revolver.calcCapital();

            //assert
            Assert.Equal(8547, (int)result);
        }

        [Fact]
        public void Strategy_Loan_revolver_term_roc_should_return_X() {
            //arrange
            Loan rctl = Loan.newRCTL(10000.00, StartOfLoan(), Expiry(),  Maturity(), RISK_RATING);
            rctl.setOutstanding(5000);

            //act
            var result = rctl.calcCapital();

            //assert
            Assert.Equal(15102, (int)result);
        }

        private DateTime? Maturity()
        {
            return DateTime.Now.AddDays(5);
        }

        private DateTime? Expiry()
        {
            return DateTime.Now.AddDays(50);
        }

        private DateTime? StartOfLoan()
        {
            return DateTime.Now.AddYears(-2);
        }

    }
}
