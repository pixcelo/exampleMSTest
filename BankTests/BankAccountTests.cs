using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [Description("正しい金額 (口座残高未満かつ 0 を上回る金額) によって口座からお金が引き出されることを確認する")]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [Description("引き落とし金額が０未満の場合にArgumentOutOfRangeException をスローすることを確認する")]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        //[TestMethod]
        //[Description("引き落とし金額が残高よりも大きい場合にArgumentOutOfRangeException をスローすることを確認する")]
        //public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        //{
        //    // Arrange
        //    double beginningBalance = 11.99;
        //    double debitAmount = 51.00;
        //    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        //    // Act and assert
        //    Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        //}

        [TestMethod]
        [Description("引き落とし金額が残高よりも大きい場合にArgumentOutOfRangeException をスローすることを確認する")]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            // 例外が発生しなかった場合、テストメソッドを失敗させる
            Assert.Fail("The expected exception was not thrown.");
        }

    }
}