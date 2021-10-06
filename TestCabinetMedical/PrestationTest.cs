using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCabinetMedical
{
    [TestClass]
    class PrestationTest
    {
        [TestMethod]
        public void TesteDatePrestationSuperieurOK()
        {
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), new DateTime(2013, 09, 15), prestation1);
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TesteDatePrestationKO()
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Intervenant intervenant1 = new Intervenant("Dupont", "Jean");
            Prestation prestation1 = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant1);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), dateCreationDossier, prestation1);
        }
    }
}
