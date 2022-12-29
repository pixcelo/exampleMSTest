using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [Description("���������z (�����c���������� 0 ��������z) �ɂ���Č������炨���������o����邱�Ƃ��m�F����")]
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
        [Description("�������Ƃ����z���O�����̏ꍇ��ArgumentOutOfRangeException ���X���[���邱�Ƃ��m�F����")]
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
        //[Description("�������Ƃ����z���c�������傫���ꍇ��ArgumentOutOfRangeException ���X���[���邱�Ƃ��m�F����")]
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
        [Description("�������Ƃ����z���c�������傫���ꍇ��ArgumentOutOfRangeException ���X���[���邱�Ƃ��m�F����")]
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

            // ��O���������Ȃ������ꍇ�A�e�X�g���\�b�h�����s������
            Assert.Fail("The expected exception was not thrown.");
        }

    }
}