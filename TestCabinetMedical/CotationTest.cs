using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;

namespace TestCabinetMedical
{
    [TestClass]
    class CotationTest
    {
        [TestMethod]
        public void TestInstanceCotationOK()
        {

            Cotation cotation = new Cotation("3e","cotation 1", 2);
            Assert.IsInstanceOfType(cotation, typeof(Cotation));
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestInstanceCotationKO()
        {
            Cotation cotation = new Cotation("3g","cotation 2", -1);
        }
    }
}
