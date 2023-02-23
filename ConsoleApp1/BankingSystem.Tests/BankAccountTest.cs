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
            BankAcc bankAccount = new BankAcc(123);
            decimal depositAmount=100;

            bankAccount.Deposit(depositAmount);
            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }
        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            BankAcc bankAccount = new BankAcc(123,2000m);
            Assert.AreEqual(2000m, bankAccount.Balance);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationException()
        {
            BankAcc bankAccount = new BankAcc(123);
            decimal depositAmount = -100;
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            BankAcc bankAccount = new BankAcc(123);
            decimal depositAmount = -100;
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            Assert.AreEqual("Negative amount", ex.Message);
        }
        [Test]
        public void NegativeCashShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAcc bankAccount = new BankAcc(123);
                decimal cashCredit = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(cashCredit));

                Assert.AreEqual(ex.Message, "Negative balance");
            }
        }
        [Test]
        public void PercentShouldBeAPositiveNumber()
        {
            {
                BankAcc bankAccount = new BankAcc(123);
                double percent = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Increase(percent));

                Assert.AreEqual(ex.Message, "The percent must be positive!");
            }
        }
        [Test]
        public void BonusShouldIncreaseBalanceWithBonusWithMessage()
        {
            BankAcc bankAccount = new BankAcc(123);
            bankAccount.Balance = bankAccount.Bonus();
            Assert.AreEqual(bankAccount.Bonus(), bankAccount.Balance);
        }

    }
}