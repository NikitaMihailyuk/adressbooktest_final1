using System;
using System.Text;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
       public void SetupApplicationManager()
        {
           app= ApplicationManager.GetInstance();
        }

    }
}
