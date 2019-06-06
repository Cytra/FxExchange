using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FX_Exchange.Library;

namespace FX_Exchange.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void SampleTest()
        {
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void Buzzer_when1_Returns1()
        {
            //[Values(1, 2, 4)] int input
            int input = 1;
            int output = BusinessLogic.GetValues(input);
            NUnit.Framework.Assert.AreEqual(input, output);
        }
    }
}
