using ForTestLibrary;
using White_Box;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject
{
    [TestClass]
    public sealed class TestLibrary
    {
        Calculator calculator = new Calculator();

        [TestMethod]
        public void Calculator_Sum_TwoTwo_FourReturn_Test()
        {
            //Arrange
            int expected = 4;

            //Act
            int actual = calculator.Sum(2, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Sum_TwoTwo_NotFiveReturn_Test()
        {
            //Arrange
            int expected = 5;

            //Act
            int actual = calculator.Sum(2, 2);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Sub_TwoTwo_ZeroReturn_Test()
        {
            //Arrange
            int expected = 0;

            //Act
            int actual = calculator.Sub(2, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Sub_TwoTwo_NotOneReturn_Test()
        {
            //Arrange
            int expected = 1;

            //Act
            int actual = calculator.Sub(2, 2);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Mul_TwoTwo_FourReturn_Test()
        {
            //Arrange
            int expected = 4;

            //Act
            int actual = calculator.Mul(2, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Mul_TwoTwo_NotFiveReturn_Test()
        {
            //Arrange
            int expected = 5;

            //Act
            int actual = calculator.Mul(2, 2);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Div_FourTwo_TwoReturn_Test()
        {
            //Arrange
            int expected = 2;

            //Act
            int actual = calculator.Div(4, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Div_TwoTwo_NotFiveReturn_Test()
        {
            //Arrange
            int expected = 5;

            //Act
            int actual = calculator.Div(2, 2);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Div_ZeroTwo_ZeroReturn_Test()
        {
            //Arrange
            int expected = 0;

            //Act
            int actual = calculator.Div(0, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Calculator_Div_FourZero_ExceptionReturn_Test()
        {
            //Arrange
            int expected = 0;

            //Act
            int actual = calculator.Div(4, 0);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public sealed class TestProject
    {
        [TestMethod]
        public void WhiteBox_Summa_TwoAndTwo_FourReturn_Test()
        {
            int expected = 4;
            int actual = Prog.Summa();
            Assert.AreEqual(expected, actual);
        }
    }
}
