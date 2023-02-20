using BankAccount;
using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DepositShouldIncreaseBalance()
        {
            BankAcc bankAccounts = new BankAcc(123);
            decimal depositAmount=100;

            bankAccounts.Deposit(depositAmount);
            Assert.AreEqual(depositAmount, bankAccounts.Balance);
        }
        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            BankAcc bankAccounts = new BankAcc(123,2000m);
            Assert.AreEqual(2000m, bankAccounts.Balance);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationException()
        {
            BankAcc bankAccounts = new BankAcc(123);
            decimal depositAmount = -100;
            Assert.Throws<InvalidOperationException>(() => bankAccounts.Deposit(depositAmount));
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            BankAcc bankAccounts = new BankAcc(123);
            decimal depositAmount = -100;
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccounts.Deposit(depositAmount));
            Assert.AreEqual("Negative amount", ex.Message);
        }
        [Test]
        public void CreditTakesCashFromBalance()
        {
            BankAcc bankAccounts = new BankAcc(123);
            decimal cash = 100;

            bankAccounts.Credit(cash);
            Assert.AreEqual(cash, bankAccounts.Balance);
        }
        [Test]
        public void BalanceShouldIncreasePercent()
        {
            BankAcc bankAccounts = new BankAcc(123);
            double percent = 10;

            bankAccounts.Increase(percent);
            Assert.AreEqual(percent, bankAccounts.Balance);
        }
        [Test]
        public void BalanceShouldIncreaseBonus()
        {

        }
    }
}