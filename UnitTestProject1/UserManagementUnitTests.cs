using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingDemonstration_1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UserManagementUnitTests
    {
       [TestMethod]
       public void ValidateLogIn_Test()
        {
            //Arrange
            UserManagement obj = new UserManagement();
            string uName = "Pragim", pwd = "Pragim@123";
            bool expectedResult = true;

            //Act
            bool actualResult = obj.ValidateLogIn(uName, pwd);

            //Assert
            Assert.AreEqual(expectedResult, actualResult, "ValidateLogIn Method is failed for Valid Input");
        }
    }
}
