using Bank;
namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            //Arrange
            Account account = new Account();
            //Act
            double balance = account.Balance;
            //Assert
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void Credit_999OnBalance0_Returns999()
        {
            // ARRANGE
            Account account= new Account();
            // ACT
            account.Credit(999);
            double balance = account.Balance;
            // ASSERT
            Assert.AreEqual(999,balance);
        }

        [TestMethod]
        public void
        Debit_500FromBalance500_Returns0()
        {
            // ARRANGE
            Account account= new Account();
            // ACT
            account.Credit(500);
            account.Debit(500);
            double balance = account.Balance;

            // ASSERT
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void
        Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            // ARRANGE
            Account account = new Account();
            // ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => account.Credit(-200) // ACT
            );
        }

        [TestMethod]
        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            // ARRANGE
            Account account = new Account();
            // ACT
            account.Credit(100);
            // ASSERT
            Assert.ThrowsException<BalanceInsufficientException>( () => account.Debit(200) );
        }


    }
}