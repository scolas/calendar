using System;
using Calendar.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendar.UnitTests
{
    [TestClass]
    public class SqlTest 
    {
        [TestMethod]
        public void LoginTest()
        {
            
            LoginController lg = new LoginController();
          // var lb = lg.login("","");

            //Assert.IsTrue(lb);
        }
    }
}
