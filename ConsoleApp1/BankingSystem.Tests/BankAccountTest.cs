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
        [Test]
        public void NegativePaymentShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAcc bankAccount = new BankAcc(123);
                decimal payment = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment));
                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void ZeroPaymentShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAcc bankAccount = new BankAcc(123);
                decimal payment = 0;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment)); //test dali hwurlq suobshtenie i dali e wqrno ako payment e negative ili 0
                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void NotEnoughPaymentShouldThrowInvalidOperationExceptionWithMessage() //test dali hwurlq suobshtenie i dali e wqrno ako payment e po malko ot balance
        {
            {
                BankAcc bankAccount = new BankAcc(123);
                decimal payment = 100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment));
                Assert.AreEqual(ex.Message, "Not enough money!");
            }
        }
        [Test]
        public void BalanceMinusPaymentIfEnoughMoney() //test dali se namalqwa balanca ako paymenta e dostatuchen
        {
            BankAcc bankAccount = new BankAcc(123, 1000);

            bankAccount.Balance = bankAccount.PaymentForCredit(100);
            Assert.AreEqual(bankAccount.PaymentForCredit(100), bankAccount.Balance);
        }
    }
}