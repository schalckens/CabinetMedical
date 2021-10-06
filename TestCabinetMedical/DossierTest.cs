using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabinetMedical.ClassesMetier;
using CabinetMedical.Exceptions;

namespace TestCabinetMedical
{
    
    [TestClass]
    public class DossierTest
    {
        [TestMethod]
        public void TestDateCreationDossierOK()
        {
            
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDateCreationDossierKO()
        {
            DateTime dateCreationDossier = DateTime.Now.AddDays(10);
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(2019, 3, 31), dateCreationDossier);
        }

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

        [TestMethod]
        public void TesteGetNbPrestationExt() { }

        [TestMethod]
        public void TesteNbJoursSoins() { }

        [TestMethod]
        public void TesteNbJoursSoinsV2() { }

        [TestMethod]
        public void TesteNbJoursSoinsV3() { }
    }
}
