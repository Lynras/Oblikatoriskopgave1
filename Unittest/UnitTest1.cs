using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblikatoriskopgave1;

namespace Unittest
{
    [TestClass]
    public class UnitTest1
    {

        FanOutput fanOutput = new FanOutput();



        [TestMethod]
        public void NameUnderTest()
        {

            try // Try
            {
                fanOutput.Name = "h";
                Assert.Fail(); // Fail
            }
            catch (Exception e)
            {
                // Catch
                Assert.AreEqual("Name is less that 2 characters", e.Message);
            }


        }

        [TestMethod]
        public void NameOnTest()
        {
            try // Try
            {
                fanOutput.Name = "hh";
                Assert.AreEqual("hh", fanOutput.Name);
            }
            catch (Exception e)
            {
                Assert.Fail("Name is less that 2 characters", e.Message);
            }
        }

        [TestMethod]
        public void NameOverTest()
        {
            try // Try
            {
                fanOutput.Name = "hhh";
                Assert.AreEqual("hhh", fanOutput.Name);
            }
            catch (Exception e)
            {
                Assert.Fail("Name is less that 2 characters", e.Message);
            }

        }

        [TestMethod]
        public void TempUnderTest()
        {

            try // Try
            {
                fanOutput.Temp = 1;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Temp is less than 15 and higher than 25", e.Message);
            }
        }


        [TestMethod]
        public void TempOnTest()
        {
            try // Try
            {
                fanOutput.Temp = 16;
                Assert.AreEqual(16, fanOutput.Temp);
            }
            catch (Exception e)
            {
                Assert.Fail("Temp is less than 15 and higher than 25", e.Message);
            }

        }

        [TestMethod]
        public void TempOverTest()
        {
            try // Try
            {
                fanOutput.Temp = 69;
                Assert.Fail("Temp is less than 15 and higher than 25", fanOutput.Temp);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Temp is less than 15 and higher than 25", e.Message);
            }
        }


        [TestMethod]
        public void HumidityUnderTest()
        {
            try
            {
                fanOutput.Humidity = 10;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Du er enten for tør eller for fugtig", e.Message);
            }
        }

        [TestMethod]
        public void HumidityOnTest()
        {
            try // Try
            {
                fanOutput.Humidity = 35;
                Assert.AreEqual(35, fanOutput.Humidity);
            }
            catch (Exception e)
            {
                Assert.Fail("Du er enten for tør eller for fugtig", e.Message);
            }
        }

        [TestMethod]
        public void HumidityOverTest()
        {
            try
            {
                fanOutput.Humidity = 100;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Du er enten for tør eller for fugtig", e.Message);
            }
        }


        [TestMethod]
        public void TestById()
        {

            try
            {
                fanOutput.Id = 1;
                Assert.AreEqual(1, fanOutput.Id);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

    }
}
